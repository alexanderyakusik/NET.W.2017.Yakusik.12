namespace Timer.Example
{
    using System;

    public sealed class Manager
    {
        public void Subscribe(Timer timer)
        {
            timer.TimerExpired += Timer_TimerExpired;
        }

        private void Timer_TimerExpired(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Manager has received message \"{e.Message}\"");
        }
    }
}
