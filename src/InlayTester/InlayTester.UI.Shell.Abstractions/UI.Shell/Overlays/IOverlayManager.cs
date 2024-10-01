// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


public interface IOverlayManager
{
    Task<Object?> ShowAsync<TViewModel>(CancellationToken cancellationToken = default)
        where TViewModel : class;

    Task<Object?> ShowAsync(String viewModelContractKey, CancellationToken cancellationToken = default);

    Task<Object?> ShowAsync(Object viewModel, CancellationToken cancellationToken = default);
}
