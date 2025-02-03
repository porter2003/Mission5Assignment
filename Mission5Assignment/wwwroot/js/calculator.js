$(document).ready(function () {
    $("#calculateBtn").click(function () {
        let hours = parseFloat($("#hoursInput").val());
        let hourlyRate = parseFloat($("#hourlyRate").val());

        if (isNaN(hours) || hours <= 0) {
            $("#errorMessage").removeClass("d-none");
            $("#totalCost").val("");
        } else {
            $("#errorMessage").addClass("d-none");
            let total = hours * hourlyRate;
            $("#totalCost").val(total.toFixed(2));
        }
    });
});
