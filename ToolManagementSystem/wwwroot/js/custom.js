
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
                { "id": "2", "parent": "#", "text": "Склад", "state": { "opened": "true" }, "a_attr": { "href": "/Tools/" } },
                { "id": "3", "parent": "#", "text": "Контракты", "state": { "opened": "true" }, "a_attr": { "href": "/Contracts" } },
                { "id": "4", "parent": "#", "text": "Наряды на работу", "state": { "opened": "true" }, "a_attr": { "href": "/Orders/" } },
                { "id": "5", "parent": "#", "text": "Сервисное обслуживание", "state": { "opened": "true" },  },
                { "id": "6", "parent": "#", "text": "Ремонт", "state": { "opened": "true" } },
                { "id": "7", "parent": "#", "text": "Администрирование", "state": { "opened": "true", "disabled": "true" } },
                { "id": "9", "parent": "#", "text": "Отчёты", "state": { "opened": "true" } },
                { "id": "8", "parent": "#", "text": "Документация", "state": { "opened": "true" } },
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
   }).bind("changed.jstree", function (e, data) {
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
    data = [{ "id": "1", "parent": "#", "text": "Вид1", "data": { "nodeId": "1" }, "state": { "opened": "true"}},
        { "id": "2", "parent": "#", "text": "Вид2", "data": { "nodeId": "2" }, "state": { "opened": "true"} },
        { "id": "3", "parent": "#", "text": "Вид3", "data": { "nodeId": "3" }, "state": { "opened": "true"} },
        { "id": "4", "parent": "1", "text": "Тип1", "data": { "nodeId": "4" }, "state": { "opened": "true"} },
        { "id": "5", "parent": "1", "text": "Тип2", "data": { "nodeId": "5" }, "state": { "opened": "true"} },
        { "id": "6", "parent": "2", "text": "Тип3", "data": { "nodeId": "6" }, "state": { "opened": "true"} },
        { "id": "7", "parent": "4", "text": "Тип4", "data": { "nodeId": "7" }, "state": { "opened": "true"} }];

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
                    "header": "Управление",
                    "tree": false,
                    "value": "nodeId",
                    "format": function (v) {
                       
                        return ("<button class='btn btn-primary mr-1 fa fa-edit' type='button'"
                            + "data-toggle='modal' data-target='#editModal' nodeId='" + v + "' @onclick='ChangeCaret'></button>"
                            + "<button class='btn btn-primary ml-1 fa fa-times' type='button'"
                            + "data-toggle='modal' data-target='#deleteModal' nodeId='" + v +"'></button>");
                    },
                },
                {
                    "header": "Наименование",
                    "tree": true,
                    "value": "title",
                    "width": "90%"
                },
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
    { "id": "7", "parent": "4", "text": "Тип4", "data": { "nodeId": "7" } }];

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

function AddClassificationEditDropdown(elementName, textboxName, dropDownName, nodeId) {
    AddClasificationTreeDropdown(elementName, textboxName);
    StopDropdownFromClosing(dropDownName);
}

