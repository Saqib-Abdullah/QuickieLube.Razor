var longpress = 2000;
var rows = $("#tblVehicleSearch").children(1).children();
var selectedRow = 1;
// holds the start time
var start;


// keydown event for the navigation using keyboard
$('body').on('keydown', function (e) {

    if (e.keyCode == 13) {
        var element = $("#tblVehicleSearch tr:eq('" + selectedRow + "')");
        EditEventCall(element);
        return false;
    }

    //Calculate new row
    if (e.keyCode == 38) {
        selectedRow--;
    } else if (e.keyCode == 40) {
        selectedRow++;
    }
    if (selectedRow >= rows.length) {
        selectedRow = 0;
    } else if (selectedRow < 0) {
        selectedRow = rows.length - 1;
    }

    //Set new row's color
    $("#tblVehicleSearch tr").removeClass("highlight");
    var selected = $("#tblVehicleSearch tr:eq('" + selectedRow + "')").hasClass("highlight");

    if (!selected) {
        $("#tblVehicleSearch tr:eq('" + selectedRow + "')").not('thead tr').addClass('highlight');
        var btnEditId = $("#tblVehicleSearch tr:eq('" + selectedRow + "')").find("a").attr('id');
        $('#' + btnEditId).focus();
    }


});



// highlight row using mouse click 
$("#tblVehicleSearch tr").click(function () {

    var selected = $(this).hasClass("highlight");
    $("#tblVehicleSearch tr").removeClass("highlight");

    var selected_index = $(this).index() + 1;
    selectedRow = selected_index;

    if (!selected) {
        $(this).not('thead tr').addClass("highlight");
        var btnEditId = $(this).find("a").attr('id');
        $('#' + btnEditId).focus();
    }
});

// edit record using mouse double click
$('#tblVehicleSearch tr').dblclick(function (e) {
    EditEventCall(this);
});

//edit record using long touch
jQuery("#tblVehicleSearch tr").on('mousedown', function (e) {
    start = new Date().getTime();
});

jQuery("#tblVehicleSearch tr").on('mouseleave', function (e) {
    start = 0;
});

jQuery("#tblVehicleSearch tr").on('mouseup', function (e) {
    if (new Date().getTime() >= (start + longpress)) {
        EditEventCall(this);
    }
});

function EditEventCall(element) {
    var btnEditHref = $(element).find("a").attr('href');
    window.location = btnEditHref;
}