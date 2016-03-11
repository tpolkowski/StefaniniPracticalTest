//definition for date imput
$("#LastPurchase").datetimepicker({
    format: "DD/MM/YYYY"
});
$("#LastPurchaseUntil").datetimepicker({
    format: "DD/MM/YYYY",
    useCurrent: false
});

//set de calendars range
$("#LastPurchase").on("dp.change", function(e) {
    $("#LastPurchaseUntil").data("DateTimePicker").minDate(e.date);
});
$("#LastPurchaseUntil").on("dp.change", function(e) {
    $("#datetimepicker6").data("DateTimePicker").maxDate(e.date);
});

//function that set the cityId value and send the form
function getRegionByCityId() {
    document.getElementById("cityIdGetRegionByCityIdForm").value = document.getElementById("cityIdGetTableByClientForm").value;
    document.getElementById("btnSubmitGetRegionByCityIdForm").click();
}