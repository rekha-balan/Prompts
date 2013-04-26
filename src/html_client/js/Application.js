$(function () {
    var promptsController = new PromptsController();
    var promptBuilder = new PromptControllerBuilder(promptsController);
    var promptsBuilder = new ControllersBuilder(promptBuilder);
    var promptingLoadingPanel = new LoadingPanelControllerBase(function (controller){
        return new PromptingLoadingPanelView(promptingLoadingPanel, promptsController.createView())
    });
    var promptsRepository = new Repository("/prompts.service/api/prompts", promptingLoadingPanel, "POST");
    var promptsRequester = new PromptsRequester(promptsRepository, promptsBuilder);
    var promptingController = new PromptingController(promptsRequester, promptsController, promptingLoadingPanel);
    var promptingView = promptingController.createView();
    promptingView.render();

    var reportCatalogBuilder = new ReportCatalogBuilder(promptingController);
    reportCatalogController = reportCatalogBuilder.build();
    reportCatalogView = reportCatalogController.createView();
    reportCatalogView.render();
});