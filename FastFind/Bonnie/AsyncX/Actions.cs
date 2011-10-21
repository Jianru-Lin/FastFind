
namespace Bonnie.AsyncX
{
    // 说明：这里只是提供了三种常见的 Action 类型
    // BasicAction 只能 Start 不能 Cancel
    // CancelableAction 能够 Start 也能 Cancel
    // ProgressAction 能够 Start 能够 Cancel 还带 Progress 进度报告
    // 以上三种 Action，都实现了 IError，因此能够异步报告错误
    // 并且实现了 IStatus，因此可以获知其当前所处的状态
    // 这只是比较常见的组合状况，任何人都可以从 IStart, ICancel, IProgress 和 IError，IStatus
    // 组合出符合自己需求的异步操作类型来，也可以补充新的接口，定义更强大的类型
    // 另外，这三个类型都依然没有从泛型具体化为特定类型
    // 因此有较高的灵活性，可以根据具体的业务需求去做具体化

    /// <summary>
    /// 基本异步操作类型
    /// 仅仅能够 Start，不能 Cancel，也没有 Progress 通知
    /// 但是错误通知是有的，如果运行过程中发生错误，能够通知使用者
    /// </summary>
    /// <typeparam name="TSender">事件发送者（sender）的类型</typeparam>
    /// <typeparam name="ErrorInfoType">错误信息的类型</typeparam>
    public abstract class BasicAction<TSender, ErrorInfoType>
        : IStart<TSender>, IError<TSender, ErrorInfoType>
    {
        public event EventHandlerX<TSender> Started;
        public event EventHandlerX<TSender> Stopped;
        public event EventHandlerX<TSender> Error;
        public ErrorInfoType ErrorInfo { get; protected set; }

        public abstract void Start();

        protected virtual void fireStarted(TSender sender)
        {
            if (Started != null)
            {
                Started(sender);
            }
        }

        protected virtual void fireStopped(TSender sender)
        {
            if (Stopped != null)
            {
                Stopped(sender);
            }
        }

        protected virtual void fireError(TSender sender)
        {
            if (Error != null)
            {
                Error(sender);
            }
        }
    }

    /// <summary>
    /// 可取消的异步操作类型
    /// 在 BasicAction 的基础上添加了 Cancel 方法，能够支持取消操作
    /// 依然不支持 Progress 进度通知
    /// </summary>
    /// <typeparam name="TSender">事件发送者（sender）的类型</typeparam>
    /// <typeparam name="ErrorInfoType">错误信息的类型</typeparam>
    public abstract class CancelableAction<TSender, ErrorInfoType>
        : BasicAction<TSender, ErrorInfoType>, ICancel<TSender>
    {
        public event EventHandlerX<TSender> Canceled;

        public abstract void Cancel();

        protected virtual void fireCanceled(TSender sender)
        {
            if (Canceled != null)
            {
                Canceled(sender);
            }
        }
    }

    /// <summary>
    /// 可取消且带有进度报告的异步操作类型
    /// 在 CancelableAction 的基础上添加了 Progress 进度报告事件
    /// </summary>
    /// <typeparam name="TSender">事件发送者（sender）的类型</typeparam>
    /// <typeparam name="ErrorInfoType">错误信息的类型</typeparam>
    public abstract class ProgressAction<TSender, ErrorInfoType>
        : CancelableAction<TSender, ErrorInfoType>, IProgress<TSender>
    {
        public event EventHandlerX<TSender> Progress;

        protected virtual void fireProgress(TSender sender)
        {
            if (Progress != null)
            {
                Progress(sender);
            }
        }
    }

}
