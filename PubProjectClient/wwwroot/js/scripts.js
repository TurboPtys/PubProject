function RegVenBtnAction() {
    document.getElementById("RegVenue").hidden = false;
    document.getElementById("RegName").hidden = true;
    document.getElementById("RegVenBtn").style.borderBottom = "8px solid  #ffffff";
    document.getElementById("RegCliBtn").style.borderBottom = 'hidden';
    document.getElementById("page-background").src = '../images/Bar/6.jpg';
}

function RegCliBtnAction() {
    document.getElementById("RegVenue").hidden = true;
    document.getElementById("RegName").hidden = false;
    document.getElementById("RegCliBtn").style.borderBottom = "8px solid  #ffffff";
    document.getElementById("RegVenBtn").style.borderBottom = 'hidden';
    document.getElementById("page-background").src = '../images/Bar/2.jpg';
    document.getElementById("inputVenuName").value = "";
    document.getElementById("inputCity").value = "";
    document.getElementById("inputStreet").value = "";
    document.getElementById("inputPhone").value = "";
    document.getElementById("inputHouseNr").value = "";
}

function datepic() {
    document.getElementById("datetimepicker1").datetimepicker();

}

$(document).ready(function () {
    $(function () {
        //$('#datetimepicker6').datetimepicker();
        $('#datetimepicker7').datetimepicker({
            useCurrent: false //Important! See issue #1075
        });
        $("#datetimepicker6").on("dp.change", function (e) {
            $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
        });
        $("#datetimepicker7").on("dp.change", function (e) {
            $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
        });
    });
});