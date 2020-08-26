
// $(document).ready(function () {   
//     $(".main-column__left-inner").mCustomScrollbar();
//     if($("#paged-list").length){
//         $("#paged-list").mCustomScrollbar({ axis:"x", theme: "dark" });
//     }
//     $(".js-btn-edit").click(function () {
//         $(this).parent().hide().next().fadeIn();
//     });
//     $(".js-btn-edit-equipment").click(function () {
//         $(this).parents(".form-info").hide().next().fadeIn();
//     });
    
//     $(".js-btn-discard").click(function () {
//         $(this).parents(".details-info__item-form, .content-heading__form").hide().prev().fadeIn();
//     });
//     $(".js-form-show").click(function () {
//         $(this).hide().next('.form-pos').fadeIn();
//     });

//     $("select").each(function(){
//         $(this).change(function () {
//             console.log("111");
//             $(this).next(".text-danger").hide();
//         });
//     });

//     if( $("#formOpenOrder").length ){
//         var $selectContracts = $("select[name='orderContract']");
//         var $selectContractsClone = $selectContracts.clone();
//         var $selectWells = $("select[name='orderWell']");
//         var $selectWellsClone = $selectWells.clone();

//         console.log($selectContractsClone);
        
//         $("select[name='orderCounterparty']").change(function () {
//             $("select[name='orderContract'], select[name='orderWell']").prop("disabled", false);
//             $("#formOpenOrder .text-danger").hide();
//             var selectedCllient = $(this).children("option:selected").val();

//                 $selectContracts.find("optgroup").remove();
//                 var $foundOptgroup = $selectContractsClone.find("optgroup[data-Counterparty='" + selectedCllient + "']");
//                 if($foundOptgroup.length != 0){
//                     $selectContracts.append($foundOptgroup.clone());
//                 }
//                 else{
//                     $selectContracts.append($selectContractsClone.find("optgroup[data-Counterparty='-1']").clone());
//                 }

//                 $selectWells.find("optgroup").remove();
//                 var $foundOptgroup2 = $selectWellsClone.find("optgroup[data-Counterparty='" + selectedCllient + "']");
//                 if($foundOptgroup2.length != 0){
//                     $selectWells.append($foundOptgroup2.clone());
//                 }
//                 else{
//                     $selectWells.append($selectWellsClone.find("optgroup[data-Counterparty='-1']").clone());
//                 }
          
//         });
//     }

//     $(".form-close-maintenance select[name='equipmentStatus']").change(function () {
//         if($(this).children("option:selected").val() == "Scrap"){
//             $(this).parent().nextAll(".form-group").hide();
//         }
//         else{
//             $(this).parent().nextAll(".form-group").show();
//         }
//     }); 
//     $(".form-close-maintenance").submit(function() {
//         var result = true;
//         var status = $("select[name='equipmentStatus'] option:selected").val();
//         if ( status == "RFU"){
//             if ( !$('input[name="operatingTime"]').val() ||
//                 !$('input[name="operatingTimeMin"]').val()){
//                 result = false;
//                 $(".form-close-maintenance .text-danger")
//                     .text("You need to input Operating time and Minimal Operating time")
//                     .show();
//             }
//             else if (parseInt($('input[name="operatingTime"]').val()) < 
//                      parseInt($('input[name="operatingTimeMin"]').val())){
//                 result = false;
//                 $(".form-close-maintenance .text-danger")
//                     .text("Operating time can't be smaller than Minimal operating time")
//                     .show();
//             }        
//         } 
//         return result;
//     });
    
//     $("#CreateEquipment").submit(function() {
//         var validate = [
//             ["department", $("select[name='department'] option:selected").val()],
//             ["category", $("select[name='category'] option:selected").val()],
//             ["type", $("select[name='type'] option:selected").val()]
//         ];
//         var result = ValidateSelects(validate);
//         return result;
//     });

//     $("#formOpenOrder").submit(function() {
//         var validate = [
//             ["orderCounterparty", $("select[name='orderCounterparty'] option:selected").val()],
//             ["orderContract", $("select[name='orderContract'] option:selected").val()],
//             ["orderWell", $("select[name='orderWell'] option:selected").val()]
//         ];
//         var result = ValidateSelects(validate);
//         return result;
//     });

//     $(".js-add-more-inputs").click(function () {
//         var newUpload = document.createElement('input');
//         newUpload.type = "file";
//         newUpload.accept = ".jpg, .jpeg, .png, .gif";
//         newUpload.name = "imgfilepath";
//         $('.form-info__item-inputs').append(newUpload);
//     });
    
//     if ($("input[name='editDateDue']").length ){
//         // console.log("IF");
//         // var today = new Date().toISOString().split('T')[0];
//         // console.log(today);
//         // $("input[name='dueDate]").attr('min', today);
//         //var today = new Date().toISOString().split('T')[0];
//         var startDate = document.getElementsByName("editDateStart")[0].val();
//         var startdate = new Date(startDate).toISOString().split('T')[0];
//        // document.getElementsByName("startDate")[0].setAttribute('min', startDate);

//         //var endDate = document.getElementsByName("contractEndDate").val();
//         document.getElementsByName("editDateDue")[0].min = startdate
//     }
    
//     if($(".history").length){
//         var i = 1;
//         $('.history-pos').each( function(){
//             $(this).attr("id", "history" + i);
//             i++;
//             $(this).simplePagination({
//                 first_content: '&lt;&lt;',
//                 previous_content: '<',
//                 next_content: '>',
//                 last_content: '>>',
//                 items_per_page: 7,
//                 number_of_visible_page_numbers: 10 // Treated as '9' (see below for explanation)
//             });
//         })
//     }    


//     $(".header-nav__icon").click(function(){
//         if ($(this).hasClass("menu-open")){
//             $(this).removeClass("menu-open");
//             $(".header-nav__container").hide();
//         }
//         else{
//             $(this).addClass("menu-open");
//             $(".header-nav__container")
//             .css("display", "flex")
//             .hide()
//             .fadeIn(200);
//         }
//     });

//     $(".form-info .form-info__heading").click(function(){
//         $(this).next(".info-dropdown").stop().slideToggle();
//     });
    

//     $(".dropdown-btn").click(function(e){
//         e.preventDefault();
//         $(this).next(".dropdown-container").slideToggle();
//     });
//     $('.collapsible').click(function () {
//         $(this).next('.accordion-panel').slideToggle();
//     });
// });

// function confirmDelete(uniqueId, isDeleteClicked) {
//     var deleteSpan = 'deleteSpan_' + uniqueId;
//     var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

//     if (isDeleteClicked) {
//         $('#' + deleteSpan).hide();
//         $('#' + confirmDeleteSpan).show();

//     } else {
//         $('#' + deleteSpan).show();
//         $('#' + confirmDeleteSpan).hide();
//     }
// }
// function GenList(listId) {
//     $(listId).simplePagination({
//         items_per_page: 5,
//         number_of_visible_page_numbers: 10,
//         first_content: '<<',
//         previous_content: '<',
//         next_content: '>',
//         last_content: '>>'
//     });
// }

// function ValidateSelects(validatearray){
//     var result = true;
//     for (var i = 0; i < validatearray.length; i++){
//         if (validatearray[i][1] == -1){
//             result = false;
//             $("[name='"+validatearray[i][0]+"']").next().show();
//         }
//     }
//     return result;
// };

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
        "plugins": ["wholerow", "search"],
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
                { "id": "3", "parent": "#", "text": "Контракты", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Contracts" } },
                { "id": "4", "parent": "#", "text": "Наряды на работу", "state": { "opened": "true" }, "a_attr": { "href": "/Orders/" } },
                { "id": "5", "parent": "#", "text": "Сервисное обслуживание", "state": { "opened": "true" } },
                { "id": "6", "parent": "#", "text": "Ремонт", "state": { "opened": "true" } },
                { "id": "7", "parent": "#", "text": "Администрирование", "state": { "opened": "true", "disabled": "true" } },
                { "id": "9", "parent": "#", "text": "Отчёты", "state": { "opened": "true" } },
                { "id": "8", "parent": "#", "text": "Документация", "state": { "opened": "true" } },
                { "id": "11", "parent": "19", "text": "Подразделения", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Departments" } },
                { "id": "10", "parent": "20", "text": "Статусы", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Statuses" } },
                { "id": "12", "parent": "20", "text": "Класификация", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Classification" } },
                { "id": "13", "parent": "20", "text": "Атрибуты", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Attributes" } },
                { "id": "14", "parent": "20", "text": "Номенклатура", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Nomenclature" } },
                { "id": "15", "parent": "21", "text": "Контрагенты", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Counterparties" } },
                { "id": "16", "parent": "21", "text": "Скважины", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Wells" } },
                { "id": "17", "parent": "7", "text": "Пользователи", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Users" } },
                { "id": "18", "parent": "7", "text": "Роли", "state": { "opened": "true" }, "a_attr": { "href": "/NRI/Roles" } },
                { "id": "19", "parent": "1", "text": "Компания", "state": { "opened": "true", "disabled": "true" } },
                { "id": "20", "parent": "1", "text": "Инструменты", "state": { "opened": "true", "disabled": "true" } },
                { "id": "21", "parent": "1", "text": "Клиенты", "state": { "opened": "true", "disabled": "true" } }
            ]
        }
    }).bind("changed.jstree", function (e, data) {
        if (data.node && !data.state.disabled) {
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



function AddClasificationTreeDropdown(elementName, textboxName) {
    var elem = '#' + elementName;
    var textboxElem = '#' + textboxName;

    $(elem).on("select_node.jstree", function (e, data) {
        $(textboxElem).val(data.node.text);
    });

    // tree data
    var data;
    data = [{ "id": "-1", "parent": "#", "text": "Добавить в корень", "data": { "title": "t-1" } },
        { "id": "1", "parent": "#", "text": "Вид1", "data": { "title": "t1" } },
    { "id": "2", "parent": "#", "text": "Вид2", "data": { "title": "t2" } },
    { "id": "3", "parent": "#", "text": "Вид3", "data": { "title": "t3" } },
    { "id": "4", "parent": "1", "text": "Тип1", "data": { "title": "t4" } },
    { "id": "5", "parent": "1", "text": "Тип2", "data": { "title": "t5" } },
    { "id": "6", "parent": "2", "text": "Тип3", "data": { "title": "t6" } },
    { "id": "7", "parent": "4", "text": "Тип4", "data": { "title": "t7" } }];

    $(elem).jstree({
        "plugins": ["wholerow", "search"],
        "core": {
            "multiple": false,
            "themes": {
                "name": "default-grid",
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

