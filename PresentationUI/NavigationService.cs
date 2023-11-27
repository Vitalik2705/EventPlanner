// <copyright file="NavigationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;

    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public NavigationService(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public void NavigateTo<T>()
            where T : class
        {
            var page = this._serviceProvider.GetRequiredService<T>() as Window;
            page?.Show();
        }
    }
}
