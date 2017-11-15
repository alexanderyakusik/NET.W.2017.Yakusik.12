namespace Timer
{
    using System;

    public class TimerEventArgs : EventArgs
    {
        #region Ctors

        /// <summary>
        /// Instaniates new timer event arguments with <paramref name="message"/> and <paramref name="tag"/>.
        /// </summary>
        /// <param name="message">Message sent to event subscribers.</param>
        /// <param name="tag">Custom object sent to event subscribers.</param>
        public TimerEventArgs(string message, object tag)
        {
            this.Message = message;
            this.Tag = tag;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Message sent to event subscribers.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Custom object sent to event subscribers.
        /// </summary>
        public object Tag { get; }

        #endregion
    }
}
