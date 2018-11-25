function RegVenBtnAction() {
    document.getElementById("RegVenue").hidden = false;
    document.getElementById("RegName").innerHTML = 'Nazwa Lokalu';
    document.getElementById("inputName").placeholder = 'Nazwa Localu';
    document.getElementById("RegVenBtn").style.borderBottom = "8px solid  #ffffff";
    document.getElementById("RegCliBtn").style.borderBottom = 'hidden';
    document.getElementById("page-background").src = '../images/Bar/6.jpg'
}

function RegCliBtnAction() {
    document.getElementById("RegVenue").hidden = true;
    document.getElementById("RegName").innerHTML = "Nick";
    document.getElementById("inputName").placeholder = "Nick";
    document.getElementById("RegCliBtn").style.borderBottom = "8px solid  #ffffff";
    document.getElementById("RegVenBtn").style.borderBottom = 'hidden';
    document.getElementById("page-background").src = '../images/Bar/2.jpg'
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