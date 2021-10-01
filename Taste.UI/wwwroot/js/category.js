import "./datatables.min.js";

var dataTable;

$(document).ready(function () {
    //initializeDataTable();
});

function loadList() {

}

export function initializeDataTable(tableId) {

    if (dataTable != null)
        dataTable.destroy();


    dataTable = $("#" + tableId).DataTable();

}


export function initTinyMCE() {

    tinymce.init({
        selector: 'textarea',
        menubar: 'file edit view insert format  table',
        plugins: 'lists'
    });
}
