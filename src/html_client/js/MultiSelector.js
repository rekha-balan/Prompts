function MultiSelector (singleSelector, rangeSelector, inverseSelector) {
    this.singleSelector = singleSelector;
    this.rangeSelector = rangeSelector;
    this.inverseSelector = inverseSelector;

    this.select = function (shiftKeyPressed, controlKeyPressed, items, item) {
        if(shiftKeyPressed && this.previousSelection != undefined) {
            this.rangeSelector.select(items, this.previousSelection, item)
        } else if(controlKeyPressed) {
            this.inverseSelector.select(items, item);
            this.previousSelection = item;
        } else {
            this.singleSelector.select(items, item);
            this.previousSelection = item;
        }

        return _.pluck(_.filter(items, function(item) {return item.isSelected}), 'model');
    }
}