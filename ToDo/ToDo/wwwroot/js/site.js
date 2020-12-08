function confirmDelete(itemId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + itemId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + itemId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }
    else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}