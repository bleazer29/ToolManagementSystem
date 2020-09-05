
var weekpicker;

function initDatePicker() {
    weekpicker = $("#weekpicker1").weekpicker({
        locale: 'ru'
    });
}
    
function dpChange() {
    console.log(weekpicker.getWeek());
    console.log(weekpicker.getYear());

    var inputField = weekpicker.find("input");
    inputField.datetimepicker().on("dp.change", function () {
        console.log(weekpicker.getWeek());
        console.log(weekpicker.getYear());
    })
}

function AddMainMenuTree(elementName) {
    var elem = '#' + elementName;
    $(elem).jstree({
        "plugins": ["wholerow"],
        "core": {
            "multiple": false,
            "themes": {
                "name": "default-dark",
                "dots": false,
                "icons": false,
                "responsive": false
            },
            'data': [
                { "id": "1", "parent": "#", "text": "НСИ", "state": { "opened": "true", "disabled": "true" } },
                { "id": "3", "parent": "#", "text": "Контракты", "state": { "opened": "true" }, "a_attr": { "href": "/Contracts" } },
                { "id": "2", "parent": "#", "text": "Управление инструментами", "state": { "opened": "true" }, "a_attr": { "href": "/Tools/" } },
                { "id": "4", "parent": "#", "text": "Наряды на работу", "state": { "opened": "true" }, "a_attr": { "href": "/Orders/" } },
                { "id": "5", "parent": "#", "text": "Сервисное обслуживание", "state": { "opened": "true" }, "a_attr": { "href": "/Maintenances/" } },
                { "id": "6", "parent": "#", "text": "Ремонт", "state": { "opened": "true" }, "a_attr": { "href": "/RepairProcesses/" } },
                { "id": "7", "parent": "#", "text": "Администрирование", "state": { "opened": "true", "disabled": "true" } },
                { "id": "9", "parent": "#", "text": "Отчёты", "state": { "opened": "true" }, "a_attr": { "href": "/Reports/" } },
                { "id": "8", "parent": "#", "text": "Документация", "state": { "opened": "true" }, "a_attr": { "href": "/Documents/" } },
                { "id": "11", "parent": "19", "text": "Подразделения", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Departments" } },
                { "id": "10", "parent": "20", "text": "Статусы", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Statuses" } },
                { "id": "12", "parent": "20", "text": "Классификация", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Classification" } },
                { "id": "13", "parent": "20", "text": "Атрибуты", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Attributes" } },
                { "id": "14", "parent": "20", "text": "Номенклатура", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Nomenclature" } },
                { "id": "15", "parent": "21", "text": "Контрагенты", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Counterparties" } },
                { "id": "16", "parent": "21", "text": "Скважины", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Wells" } },
                { "id": "17", "parent": "7", "text": "Пользователи", "state": { "opened": "true" }, "a_attr": { "href": "/Administrative/Users" } },
                { "id": "18", "parent": "7", "text": "Роли", "state": { "opened": "true" }, "a_attr": { "href": "/Administrative/Roles" } },
                { "id": "19", "parent": "1", "text": "Компания", "state": { "opened": "true", "disabled": "true" } },
                { "id": "20", "parent": "1", "text": "Инструменты", "state": { "opened": "true", "disabled": "true" } },
                { "id": "21", "parent": "1", "text": "Клиенты", "state": { "opened": "true", "disabled": "true" } }
            ]
        }
    }).on("changed.jstree", function (e, data) {
        if (data.node) {
            document.location = data.node.a_attr.href;
        }
    });
}

function GetWindowInnerSize() {
    return window.innerWidth;
}

function addResizeEvent() {
    window.addEventListener('resize', function () {
        if (this.document.documentElement.clientWidth < 780) {
            $('#sidebarShowBtn').click();
            if ($('.tree-container').hasClass('collapse') == false) {
                $('.tree-container').addClass('collapse');
            }
        }
    });
}

function initTooltips() {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
}

function AddClasificationTree(elementName) {
    var elem = '#' + elementName;
    // tree data
    var data;
    data = [{ "id": "1", "parent": "#", "text": "Вид1", "data": { "nodeId": "1" }, "state": { "opened": "true" } },
    { "id": "2", "parent": "#", "text": "Вид2", "data": { "nodeId": "2" }, "state": { "opened": "true" } },
    { "id": "3", "parent": "#", "text": "Вид3", "data": { "nodeId": "3" }, "state": { "opened": "true" } },
    { "id": "4", "parent": "1", "text": "Тип1", "data": { "nodeId": "4" }, "state": { "opened": "true" } },
    { "id": "5", "parent": "1", "text": "Тип2", "data": { "nodeId": "5" }, "state": { "opened": "true" } },
    { "id": "6", "parent": "2", "text": "Тип3", "data": { "nodeId": "6" }, "state": { "opened": "true" } },
    { "id": "7", "parent": "4", "text": "Подтип4", "data": { "nodeId": "7" }, "state": { "opened": "true" } }];
    var i = 0;
    $(elem).jstree({
        "plugins": ["grid", "wholerow", "search"],
        "core": {
            "multiple": false,
            "themes": {
                "name": "default-grid",
                "dots": false,
                "icons": false
            },
            "data": data
        },
        "grid": {
            "columns": [
                {
                    "header": "#",
                    "tree": false,
                    "cellClass": "tree-col-num",
                    "value": "",
                },
                {
                    "header": "Наименование",
                    "tree": true,
                    "value": "title",
                    "width": "100%"
                },
                {
                    "header": "Управление",
                    "tree": false,
                    "cellClass": "jstree-grid-buttons-cell",
                    "value": "nodeId",

                    "format": function (v) {

                        return ("<button class='btn btn-primary mr-1 fa fa-edit edit-button' type='button'"
                            + "data-toggle='modal' data-target='#editModal' nodeId='" + v + "' @onclick='ChangeCaret'></button>"
                            + "<button class='btn btn-primary ml-1 fa fa-trash-alt delete-button' type='button'"
                            + "data-toggle='modal' data-target='#deleteModal' nodeId='" + v + "'></button>");
                    },
                }
            ]
        }
    });
}

function AddClasificationTreeDropdown(elementName, textboxName) {
    var elem = '#' + elementName;
    var textboxElem = '#' + textboxName;

    $(elem).on("select_node.jstree", function (e, data) {
        $(textboxElem).val(data.node.text);
    });

    // tree data

    var data;
    data = [
        { "id": "-1", "parent": "#", "text": "Добавить в корень", "data": { "title": "t-1" } },
        { "id": "1", "parent": "#", "text": "Вид1", "data": { "nodeId": "1" } },
        { "id": "2", "parent": "#", "text": "Вид2", "data": { "nodeId": "2" } },
        { "id": "3", "parent": "#", "text": "Вид3", "data": { "nodeId": "3" } },
        { "id": "4", "parent": "1", "text": "Тип1", "data": { "nodeId": "4" } },
        { "id": "5", "parent": "1", "text": "Тип2", "data": { "nodeId": "5" } },
        { "id": "6", "parent": "2", "text": "Тип3", "data": { "nodeId": "6" } },
        { "id": "7", "parent": "4", "text": "Подтип4", "data": { "nodeId": "7" } }];

    $(elem).jstree({
        "plugins": ["wholerow", "search"],
        "core": {
            "multiple": false,
            "themes": {
                "name": "default",
                "dots": false,
                "icons": false,
                "responsive": false
            },
            "data": data
        },

    });


}

function StopDropdownFromClosing(dropDownName) {
    var dropDownElem = '#' + dropDownName;

    $(dropDownElem).on('click', function (event) {
        // The event won't be propagated up to the document NODE and 
        // therefore delegated events won't be fired
        event.stopPropagation();
    });
}

function DeleteClassificationEditDropdown(elementName) {
    var elem = '#' + elementName;
    $(elem).children().remove();
}

function AddRolesTree(elementName) {
    var elem = '#' + elementName;
    var data = [
        { "id": "12", "parent": "20", "text": "Классификация", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Classification" }, "data": { "nodeId": "12", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "13", "parent": "20", "text": "Атрибуты", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Attributes" }, "data": { "nodeId": "13", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "14", "parent": "20", "text": "Номенклатура", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Nomenclature" }, "data": { "nodeId": "14", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "15", "parent": "21", "text": "Контрагенты", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Counterparties" }, "data": { "nodeId": "15", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "16", "parent": "21", "text": "Скважины", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Wells" }, "data": { "nodeId": "16", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "17", "parent": "7", "text": "Пользователи", "state": { "opened": "true" }, "a_attr": { "href": "/Administrative/Users" }, "data": { "nodeId": "17", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "1", "parent": "#", "text": "НСИ", "state": { "opened": "true"}, "data": { "nodeId": "1", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "2", "parent": "#", "text": "Склад", "state": { "opened": "true" }, "a_attr": { "href": "/Tools/" }, "data": { "nodeId": "2", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "3", "parent": "#", "text": "Контракты", "state": { "opened": "true" }, "a_attr": { "href": "/Contracts" }, "data": { "nodeId": "3", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "4", "parent": "#", "text": "Наряды на работу", "state": { "opened": "true" }, "a_attr": { "href": "/Orders/" }, "data": { "nodeId": "4", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "5", "parent": "#", "text": "Сервисное обслуживание", "state": { "opened": "true" }, "data": { "nodeId": "5", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "6", "parent": "#", "text": "Ремонт", "state": { "opened": "true" }, "data": { "nodeId": "6", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "7", "parent": "#", "text": "Администрирование", "state": { "opened": "true"}, "data": { "nodeId": "7", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "9", "parent": "#", "text": "Отчёты", "state": { "opened": "true" }, "data": { "nodeId": "8", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "8", "parent": "#", "text": "Документация", "state": { "opened": "true" }, "data": { "nodeId": "9", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "11", "parent": "19", "text": "Подразделения", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Departments" }, "data": { "nodeId": "10", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "10", "parent": "20", "text": "Статусы", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Statuses" }, "data": { "nodeId": "11", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "18", "parent": "7", "text": "Роли", "state": { "opened": "true" }, "a_attr": { "href": "/Administrative/Roles" }, "data": { "nodeId": "18", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "19", "parent": "1", "text": "Компания", "state": { "opened": "true"}, "data": { "nodeId": "19", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "20", "parent": "1", "text": "Инструменты", "state": { "opened": "true"}, "data": { "nodeId": "20", "view": "true", "add": "true", "edit": "true", "delete": "true" } },
        { "id": "21", "parent": "1", "text": "Клиенты", "state": { "opened": "true"}, "data": { "nodeId": "21", "view": "true", "add": "true", "edit": "true", "delete": "true" } }
    ]

    $(elem).jstree({
        "plugins": ["grid", "wholerow", "search"],
        "core": {
            "multiple": false,
            "themes": {
                "name": "custom-roles-grid",
                "dots": false,
                "icons": false
            },
            "data": data
        },
        "grid": {
            "columns": [
                {
                    "header": "Наименование",
                    "tree": true,
                    "value": "title",
                    "width": "50%"
                },
                {
                    "header": "Просмотр",
                    "tree": false,
                    "value": "view",
                    "format": function (v) {
                        var checked = "";
                        if (v == true) {
                            checked = "checked='true'"
                        }

                        var res = "<input type='checkbox' " + checked + " > </input>"
                        return (res);
                    },
                },
                {
                    "header": "Редактирование",
                    "tree": false,
                    "value": "edit",
                    "format": function (v) {
                        var checked = "";
                        if (v == true) {
                            checked = "checked='true'"
                        }

                        var res = "<input type='checkbox' " + checked + " > </input>"
                        return (res);
                    },
                },
                {
                    "header": "Добавление",
                    "tree": false,
                    "value": "add",
                    "format": function (v) {
                        var checked = "";
                        if (v == true) {
                            checked = "checked='true'"
                        }

                        var res = "<input type='checkbox' " + checked + " > </input>"
                        return (res);
                    },
                },
                {
                    "header": "Удаление",
                    "tree": false,
                    "value": "delete",
                    "format": function (v) {
                        var checked = "";
                        if (v == true) {
                            checked = "checked='true'"
                        }

                        var res = "<input type='checkbox' " + checked + " > </input>"
                        return (res);
                    },
                }
            ]
        }
    });
}

//function AddPartRow(tBodyName, counter) {
//    var tBodyElem = '#' + tBodyName;
//    $(tBodyElem).append(
//        "<tr id='parts-row-" + counter + "'><td class= 'text-left'>"  
//        + "<button id='parts-row_button-" + counter + "' onclick='RemoveTableRow(this.id)' class='btn btn-primary fa fa-minus w-100' type='button'></button>"
//            + "</td >"
//        + "<td class='text-left'><select class='form-control'></select></td>"
//            + "<td class='text-left'></td>"
//            + "</tr>"
//    );
//}

function ClearTable(tBodyName) {
    var tBodyElem = '#' + tBodyName;
    $(tBodyElem).empty();
}

function RemoveTableRow(tBodyName) {
    var tBodyElem = '#' + tBodyName.substr(0, tBodyName.lastIndexOf("_")) + tBodyName.substr(tBodyName.lastIndexOf("-"));
    $(tBodyElem).remove();
}

function AddClassificationRow(tBodyName, counter) {
    var tBodyElem = '#' + tBodyName;
    $(tBodyElem).append(
        "<tr id='classification-row-" + counter + "'><td class= 'text-left'></td><td class= 'text-left'>"
        + "<button id='classification-row_button-" + counter + "' onclick='RemoveTableRow(this.id)' class='btn btn-primary fa fa-minus w-100' type='button'></button>"
        + "</td >"
        + "<td class='text-left'><select class='form-control'><option selected = 'selected'> Длина</option><option>Ширина</option><option>Вес</option></select></td>"
        + "<td class='text-left'></td>"
        + "<td class='text-left'><input class='form-control'/></td>"
        + "</tr>"
    );
}

function AddRolesRow(tBodyName, counter) {
    var tBodyElem = '#' + tBodyName;
    $(tBodyElem).append(
        "<tr id='role-row-" + counter + "'><td class= 'text-left'></td><td class= 'text-left'>"
        + "<button id='role-row_button-" + counter + "' onclick='RemoveTableRow(this.id)' class='btn btn-primary fa fa-minus w-100' type='button'></button>"
        + "</td >"
        + "<td class='text-left'><select class='form-control'></select></td>"
        + "</tr>"
    );
}

function test () {
    $(document).ready(function () {
        $('[data-toggle="popover"]').popover({
            "content": function () {
                return $(this).next(".popup-content").html();
            }
        });
    });
}

