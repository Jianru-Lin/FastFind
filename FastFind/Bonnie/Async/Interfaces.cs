using System;

namespace Bonnie.Async
{
    /// <summary>
    /// 异步错误通知接口
    /// 实现本接口的类能够在发生错误时通知订阅者
    /// 由于 try catch 机制只能以同步方式抛出/接收错误
    /// 而且会影响控制流（一旦 thow 就不能继续往下了）
    /// 因此在异步环境下，try catch相当难用，会导致一系列设计问题
    /// 实现本接口的类能够以很轻松的方式与调用者进行沟通，简单而灵活
    /// 尽管不能提供 try catch 那样的底层保护，但一般不是问题
    /// </summary>
    /// <typeparam name="ErrorType">Error 事件的类型</typeparam>
    public interface IError<ErrorType>
        where ErrorType : EventArgs
    {
        event EventHandler<ErrorType> Error;
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
    /// <typeparam name="StartedType">Started 事件的类型</typeparam>
    /// <typeparam name="StoppedType">Stopped 事件的类型</typeparam>
    public interface IStart<StartedType, StoppedType> 
        where StartedType : EventArgs
        where StoppedType : EventArgs
    {
        void Start();
        event EventHandler<StartedType> Started;
        event EventHandler<StoppedType> Stopped;
    }

    /// <summary>
    /// 实现本接口的类能够支持“Cancel”操作，终止正在进行的操作
    /// 调用 Cancel 方法，意味着希望取消掉当前正在进行的操作，但对于是否能够成功
    /// 取消，需要由接口的实现者去与使用者达成约定
    /// </summary>
    /// <typeparam name="CanceledType">Canceled 事件的类型</typeparam>
    public interface ICancel<CanceledType>
        where CanceledType : EventArgs
    {
        void Cancel();
        event EventHandler<CanceledType> Canceled;
    }

    /// <summary>
    /// 实现了本接口的类型，能够提供进度报告机制
    /// 对于那些花费长时间，处理的数据量可能较大，且工作进度可以评估的操作来说
    /// 提供进度报告机制能够极大的改善用户使用体验，摆脱焦虑和担心
    /// </summary>
    /// <typeparam name="ProgressType">Progress 事件的类型</typeparam>
    public interface IProgress<ProgressType>
        where ProgressType : EventArgs
    {
        event EventHandler<ProgressType> Progress;
    }
}
