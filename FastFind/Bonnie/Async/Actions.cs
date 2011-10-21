using System;

namespace Bonnie.Async
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
    /// <typeparam name="StartedType">Started 事件类型</typeparam>
    /// <typeparam name="StoppedType">Stopped 事件类型</typeparam>
    /// <typeparam name="ErrorType">Error 事件类型</typeparam>
    public abstract class BasicAction<StartedType, StoppedType, StatusType, ErrorType>
        : IStart<StartedType, StoppedType>, IStatus<StatusType>, IError<ErrorType>
        where StartedType : EventArgs
        where StoppedType : EventArgs
        where ErrorType : EventArgs
    {
        public event EventHandler<StartedType> Started;
        public event EventHandler<StoppedType> Stopped;
        public event EventHandler<ErrorType> Error;

        public StatusType Status 
        {
            get
            {
                return status;
            }
        }

        protected StatusType status;

        public abstract void Start();

        protected virtual void fireStarted(StartedType eventArgs)
        {
            if (Started != null)
            {
                Started(this, eventArgs);
            }
        }

        protected virtual void fireStopped(StoppedType eventArgs)
        {
            if (Started != null)
            {
                Stopped(this, eventArgs);
            }
        }

        protected virtual void fireError(ErrorType eventArgs)
        {
            if (Started != null)
            {
                Error(this, eventArgs);
            }
        }
    }

    /// <summary>
    /// 可取消的异步操作类型
    /// 在 BasicAction 的基础上添加了 Cancel 方法，能够支持取消操作
    /// 依然不支持 Progress 进度通知
    /// </summary>
    /// <typeparam name="StartedType">Started 事件类型</typeparam>
    /// <typeparam name="CanceledType">Canceled 事件类型</typeparam>
    /// <typeparam name="StoppedType">Stopped 事件类型</typeparam>
    /// <typeparam name="ErrorType">Error 事件类型</typeparam>
    public abstract class CancelableAction<StartedType, CanceledType, StoppedType, StatusType, ErrorType>
        : BasicAction<StartedType, StoppedType, StatusType, ErrorType>, ICancel<CanceledType>
        where StartedType : EventArgs
        where CanceledType : EventArgs
        where StoppedType : EventArgs
        where ErrorType : EventArgs
    {
        public event EventHandler<CanceledType> Canceled;

        public abstract void Cancel();

        protected virtual void fireCanceled(CanceledType eventArgs)
        {
            if (Canceled != null)
            {
                Canceled(this, eventArgs);
            }
        }
    }

    /// <summary>
    /// 可取消且带有进度报告的异步操作类型
    /// 在 CancelableAction 的基础上添加了 Progress 进度报告事件
    /// </summary>
    /// <typeparam name="StartedType">Started 事件类型</typeparam>
    /// <typeparam name="ProgressType">Progress 事件类型</typeparam>
    /// <typeparam name="CanceledType">Canceled 事件类型</typeparam>
    /// <typeparam name="StoppedType">Stopped 事件类型</typeparam>
    /// <typeparam name="ErrorType">Error 事件类型</typeparam>
    public abstract class ProgressAction<StartedType, ProgressType, CanceledType, StoppedType, StatusType, ErrorType>
        : CancelableAction<StartedType, CanceledType, StoppedType, StatusType, ErrorType>, IProgress<ProgressType>
        where StartedType : EventArgs
        where ProgressType : EventArgs
        where CanceledType : EventArgs
        where StoppedType : EventArgs
        where ErrorType : EventArgs
    {
        public event EventHandler<ProgressType> Progress;

        protected virtual void fireProgress(ProgressType eventArgs)
        {
            if (Progress != null)
            {
                Progress(this, eventArgs);
            }
        }
    }

}
