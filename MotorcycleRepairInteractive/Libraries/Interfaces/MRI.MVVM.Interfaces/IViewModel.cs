﻿using System.ComponentModel;

namespace MRI.MVVM.Interfaces
{
  /// <summary>
  /// Base interface for view models consumed by <see cref="IView{TViewModel}"/>
  /// </summary>
  public interface IViewModel
    : INotifyPropertyChanged
  {
  }
}