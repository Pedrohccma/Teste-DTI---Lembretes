$(document).ready(function () {
    GetAllNotes();

    $("#add-new-note").click(function () {
        GetAllNotes();
    });

    $("#add-new-note").click(function () {
        var name = document.getElementById("name").value;
        var date = document.getElementById("date").value;

        $.ajax({
            type: "POST",
            url: "/Note/AddNotes",
            data: { name: name, date: date },
            success: function (result) {
                GetAllNotes();
            },
            error: function (error) {
                return error
            }
        });
    });

    function GetAllNotes() {
        $.ajax({
            type: "GET",
            url: "/Note/GetNotes",
            success: function (result) {
                showNotes(result);
            },
            error: function (error) {
                return error
            }
        });
    }

    function showNotes(notes) {
        $("#note-list").empty();

        if (notes.length === 0) {
            var alertEmptyList = $("<p>").text("Não foram encontrados lembretes!");
            $("#note-list").append(alertEmptyList);
            return;
        }

        var noteGroup = {};

        for (var i = 0; i < notes.length; i++) {
            var note = notes[i];
            var data = new Date(note.date).toLocaleDateString('en-GB');

            if (!noteGroup[data]) {
                noteGroup[data] = [];
            }

            noteGroup[data].push(note);
        }

        for (var data in noteGroup) {
            var dayNotes = noteGroup[data];

            var ul = $("<ul>").text(data);
            $("#note-list").append(ul);

            for (var j = 0; j < dayNotes.length; j++) {
                var dayNote = dayNotes[j];

                var li = $("<li>").text(dayNote.name);
                $("#note-list").append(li);

                var bttnRemove = $("<button>").text("Remover");
                bttnRemove.data("id", dayNote.id);
                bttnRemove.click(function () {
                    var id = $(this).data("id");
                    RemoveNotes(id);
                });
                $("#note-list").append(bttnRemove);
            }
        }

        function RemoveNotes(id) {
            $.ajax({
                url: "/Note/RemoveNotes",
                type: "POST",
                data: { id: id },
                success: function () {
                    GetAllNotes();
                    return Error
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
    }
});
