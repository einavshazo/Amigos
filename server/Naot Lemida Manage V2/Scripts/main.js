
var clickedDate;
    $('#calendar').fullCalendar({
        theme: false,
        editable: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        defaultDate: '12/06/2016',
        defaultView: 'month',
        editable: true,
        defaultView: 'agendaWeek',
        allDayText: "כל היום",
        slotLabelFormat: 'HH:mm',
        editable: false,
        isRTL: true,
        monthNames: ['ינואר', 'פברואר', 'מרץ', 'אפריל', 'מאי', 'יוני', 'יולי', 'אוגוסט', 'ספטמבר', 'אוקטובר', 'נובמבר', 'דצמבר'],
        monthNamesShort: ['ינואר', 'פברואר', 'מרץ', 'אפריל', 'מאי', 'יוני', 'יולי', 'אוגוסט', 'ספטמבר', 'אוקטובר', 'נובמבר', 'דצמבר'],
        dayNames: ["יום ראשון", "יום שני", "יום שלישי", "יום רביעי", "יום חמישי", "יום שישי", "יום שבת"],
        dayNamesShort: ["ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי", "שבת"],
        buttonText: {
            prev: "<",
            next: ">",
            prevYear: "<",
            nextYear: ">",
            today: "היום",
            month: "חודש",
            week: "שבוע",
            day: "יום"
        },
        dayClick: function (date, allDay, jsEvent, view) {
            clickedDate = date.format();
            $("#dialog").dialog('open');
            $('#Start').val(clickedDate);

        },
    });
    $('#dialog').dialog({
        title: "יצירת אופציה",
        modal: true,
        width: 350,
        height: 500,
        autoOpen: false,
        buttons: {
            "צור": function () {
                $.ajax({
                    url: "/Options/Create",
                    type: "POST",
                    data: $('form').serialize(),
                    datatype: "json",
                    success: function (result) {

                        $("#dialogContent").html(result);

                    }
                });
            }
        },

        show:
        {
            effect: 'clip',
            duration: 450
        },
        hide: {
            effect: 'clip',
            duration: 450
        },
        showOpt: { direction: 'up' },
        close: function (event, ui) { $(this).dialog('close'); },
       
    });
    
    $(".close").on("click", function (e) {
        e.preventDefault();
        $(this).closest(".dialog").dialog("close");
    });