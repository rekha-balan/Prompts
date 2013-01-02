var PromptingView = Class.extend({
    init: function (controller, loadingPanelView) {
    	this.controller = controller;
    	this.loadingPanelView = loadingPanelView;

        this.root = $("#prompts");
        this.root.append(loadingPanelView.render());
    },

    onRetryClick: function () {
        this.controller.onRetryClick();
    },

    render: function () {
    	this.loadingPanelView.root.filter("#retry").click($.proxy(this.onRetryClick, this));
        return this.root;
    }
});