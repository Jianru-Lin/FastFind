using System;

// 本命名空间（Bonnie.AsyncX）与 Bonnie.Async 都是对异步调用风格的封装
// 主要区别在于：
// 一、事件处理风格不同——新风格 vs. 传统风格
// 后者使用 EventHandler<T> 作为事件的委托类型，符合.NET传统风格
// 本命名空间则使用了自定义的 EventHandlerX<T> 作为事件的委托类型
// 这两者的定义分别为：
// public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
// public delegate void EventHandlerX<TSender>(TSender sender);
// EventHandlerX 与 EventHandler 的差别表面上是有无 EventArgs，实际上
// 是事件处理风格的本质不同，传统的.NET风格的 EventHandler<T> 主要是把事件相关的信息
// 单独放在一个 EventArgs 类的子类对象中，传递给调用者，为大多数开发者所熟知
// EventHandlerX<T> 则是专门为新的异步调用风格设计的，去除了 EventArgs
// 因为在新的异步调用风格中，类对象是极其细粒度的，一个类的对象就对应了一个方法调用
// 其参数和返回值都是放在对象属性中的，因此事件相关的信息在类对象的属性中可以直接获取到
// 无需独立出 EventArgs 来单独存放
// 这是一种针对特定场景的专门化设计，EventHandlerX 可以大大简化相关操作，非常适合新型异步调用风格
// 二、泛型支持不同——事件类型泛型化 vs. 动作类型泛型化
// 在一中已经提及到本命名空间（Bonnie.AsyncX）与 Bonnie.Async 在事件处理风格上的差异
// 由于这一差异的存在，导致了本命名空间在泛型支持上与后者也有所不同
// Bonnie.Async 命名空间中的接口和类都带有泛型参数，但是这些泛型参数主要是针对 EventHandler 中
// 的 EventArgs 的具体类型的。而本命名空间中的接口和类采用的是 EventHandlerX，因此不涉及 EventArgs
// 也就不存在对 EventArgs 的泛型支持问题，但是为了方便，本命名空间提供了针对 sender（事件发送者）的
// 泛型支持，可以大大方便事件的订阅者，无需进行强制类型转换，更加容易使用
// 三、IError 接口变化
// 本命名空间中的 IError 接口新增了 ErrorMessage 用于提示错误信息
// Bonnie.Async 命名空间中的 IError 接口不需要 ErrorMessage 是因为它把错误信息封装在了 EventArgs 中

namespace Bonnie.AsyncX
{
    /// <summary>
    /// 针对新型异步调用风格下的事件处理方法的原型定义
    /// 相比与.NET自带的 EventHandler，主要改变是：
    /// 1、去除了 EventArgs
    /// 2、对 sender 提供了泛型支持
    /// </summary>
    /// <typeparam name="T">sender 的泛型类型</typeparam>
    /// <param name="sender">事件发出者</param>
    [Serializable]
    public delegate void EventHandlerX<TSender>(TSender sender);

    /// <summary>
    /// 异步错误通知接口
    /// 实现本接口的类能够在发生错误时通知订阅者
    /// 由于 try catch 机制只能以同步方式抛出/接收错误
    /// 而且会影响控制流（一旦 thow 就不能继续往下了）
    /// 因此在异步环境下，try catch相当难用，会导致一系列设计问题
    /// 实现本接口的类能够以很轻松的方式与调用者进行沟通，简单而灵活
    /// 尽管不能提供 try catch 那样的底层保护，但一般不是问题
    /// </summary>
    /// <typeparam name="TSender">事件发送者（sender）的类型</typeparam>
    /// <typeparam name="ErrorType">错误信息的类型</typeparam>
    public interface IError<TSender, ErrorInfoType>
    {
        ErrorInfoType ErrorInfo { get; }
        event EventHandlerX<TSender> Error;
    }

    /// <summary>
    /// 状态接口
    /// 实现了本接口的类的对象能够告知使用者自己当前处于何种状态
    /// 具体有哪些状态，状态由何种类型的数据表示等问题，由接口的实现者自己决定
    /// </summary>
    /// <typeparam name="StatusType">Status 类型</typeparam>
    public interface IStatus<StatusType>
    {
        StatusType Status { get; }
    }

    /// <summary>
    /// 最简单的异步操作，仅仅支持 Start 方法
    /// 不能 Cancel，也没有 Progress 通知
    /// 但是在操作完成时会发出 Stopped 事件通知
    /// 为了保持对称性，也提供了 Started 事件通知
    /// </summary>
    /// <typeparam name="TSender">事件发送者（sender）的类型</typeparam>
    public interface IStart<TSender> 
    {
        void Start();
        event EventHandlerX<TSender> Started;
        event EventHandlerX<TSender> Stopped;
    }

    /// <summary>
    /// 实现本接口的类能够支持“Cancel”操作，终止正在进行的操作
    /// 调用 Cancel 方法，意味着希望取消掉当前正在进行的操作，但对于是否能够成功
    /// 取消，需要由接口的实现者去与使用者达成约定
    /// </summary>
    /// <typeparam name="TSender">事件发送者（sender）的类型</typeparam>
    public interface ICancel<TSender>
    {
        void Cancel();
        event EventHandlerX<TSender> Canceled;
    }

    /// <summary>
    /// 实现了本接口的类型，能够提供进度报告机制
    /// 对于那些花费长时间，处理的数据量可能较大，且工作进度可以评估的操作来说
    /// 提供进度报告机制能够极大的改善用户使用体验，摆脱焦虑和担心
    /// </summary>
    /// <typeparam name="TSender">事件发送者（sender）的类型</typeparam>
    public interface IProgress<TSender>
    {
        event EventHandlerX<TSender> Progress;
    }
}
