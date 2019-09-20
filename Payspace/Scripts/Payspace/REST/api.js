$(document).ready(function () {
    $("#calculate").on("click", function () {
        $("#result").html('');
        this.disabled = true;
        $("#calculate").html('Busy...');
        var income = $("#income").val();
        var code = $("#code").val();
        var data = { Income: income, Code: code };
        $.post("../../api/taxcalculator/calculatetax", data, function (res) {
            if (res > 0) {
                $("#result").html('Tax Result: <b>' + res + '</b>');
            } else {
                $("#result").html('Unknown code specified or income out of range');
            }
            $("#calculate").html('Calculate Tax');
            $("#calculate").removeAttr('disabled');
        }, "json");
    });
});