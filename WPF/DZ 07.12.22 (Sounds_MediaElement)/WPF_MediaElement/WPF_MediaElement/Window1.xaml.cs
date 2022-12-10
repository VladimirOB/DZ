﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Media_Element
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SynchronizedAnimation : Window
    {

        public SynchronizedAnimation()
        {
            InitializeComponent();
        }
        private bool suppressSeek;

        /// <summary>
        /// метод позволяет перематывать проигрываемый отрывок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliderPosition_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (!suppressSeek)
                MediaStoryboard.Storyboard.Seek(st1, TimeSpan.FromSeconds(sliderPosition.Value), TimeSeekOrigin.BeginTime);
        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            // настройка слайдера перемотки
            sliderPosition.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
        }

        /// <summary>
        /// метод запускается для обновления текущей проигрываемой позиции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            Clock storyboardClock = (Clock)sender;

            if (storyboardClock.CurrentProgress == null)
            {
                lblTime.Text = "";
            }
            else
            {
                // настроить вывод текущего времени проигрывания и позиции слайдера
                lblTime.Text = storyboardClock.CurrentTime.ToString();
                suppressSeek = true;
                sliderPosition.Value = storyboardClock.CurrentTime.Value.TotalSeconds;
                suppressSeek = false;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // загрузка другого музыкального отрывка в MediaTimeline
            Storyboard st = (Storyboard)this.Resources["MediaStoryboardResource"];
            MediaTimeline line1 = (MediaTimeline)st.Children[0];
            line1.Source = new Uri("runaway.mp3", UriKind.RelativeOrAbsolute);
        }

        private void sliderPosition_ValueChanged()
        {

        }
    }
}
