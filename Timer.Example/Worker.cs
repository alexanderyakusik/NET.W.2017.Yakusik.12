namespace Timer.Example
{
    using System;

    public sealed class Worker
    {
        public void Subscribe(Timer timer)
        {
            timer.TimerExpired += Timer_TimerExpired;
        }

        private void Timer_TimerExpired(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Worker has received message \"{e.Message}\".");
        }
    }
}
