namespace Timer
{
    using System;
    using System.Threading;

    public class Timer
    {
        #region Private fields

        private const string DefaultTimerMessage = "Timer has expired.";

        private readonly TimeSpan expirationTime;

        #endregion

        #region Ctors

        /// <summary>
        /// Instaniates Timer object with <paramref name="expirationTime"/>.
        /// </summary>
        /// <param name="expirationTime">Timer expiration time.</param>
        public Timer(TimeSpan expirationTime)
        {
            this.expirationTime = expirationTime;
        }

        /// <summary>
        /// Instaniates Timer object with <paramref name="milliseconds"/>.
        /// </summary>
        /// <param name="milliseconds">Amount of milliseconds before timer expiration.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="milliseconds"/> is less than one.</exception>
        public Timer(long milliseconds)
        {
            milliseconds = milliseconds > 0
                ? milliseconds
                : throw new ArgumentOutOfRangeException($"{nameof(milliseconds)} must be greater than zero.");

            this.expirationTime = TimeSpan.FromMilliseconds(milliseconds);
        }

        #endregion

        #region Events

        /// <summary>
        /// Event triggered on reaching expiration time.
        /// </summary>
        public event EventHandler<TimerEventArgs> TimerExpired;

        #endregion

        #region Methods

        #region Public methods

        /// <summary>
        /// Starts waiting procedure of a timer.
        /// </summary>
        public void Start()
        {
            ThreadPool.QueueUserWorkItem(obj =>
            {
                Thread.Sleep(expirationTime);
                OnTimerExpired(new TimerEventArgs(DefaultTimerMessage, null));
            });
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Method called on timer expiration event.
        /// </summary>
        /// <param name="e">Timer expiration event arguemnts.</param>
        protected virtual void OnTimerExpired(TimerEventArgs e)
        {
            EventHandler<TimerEventArgs> eventHandler = TimerExpired;

            eventHandler?.Invoke(this, e);
        }

        #endregion

        #endregion
    }
}
