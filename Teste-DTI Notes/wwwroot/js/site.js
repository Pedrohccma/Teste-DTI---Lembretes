$(document).ready(function () {
    GetAllNotes();

    $("#add-new-note").click(function () {
        let name = document.getElementById("name").value;
        let date = document.getElementById("date").value;

        let errorMessage = AddNoteValidations(name, date);

        if (errorMessage != null) {
            swal(errorMessage, { icon: "error" })
            return;
        }

        AddNotes(name, date);
    });
});

function GetAllNotes() {
    $.ajax({
        type: "GET",
        url: "/Note/GetNotes",
        success: function (notes) {
            ShowNotes(notes);
        },
        error: function (error) {
            return error;
        }
    });
}

function AddNotes(name, date) {
    $.ajax({
        type: "POST",
        url: "/Note/AddNotes",
        data: { name: name, date: date },
        success: function () {
            GetAllNotes();
        },
        error: function (error) {
            console.log(error)
            swal(error.responseText, { icon: "error" })
        }
    });
}

function RemoveNotes(id) {
    $.ajax({
        url: "/Note/RemoveNotes",
        type: "POST",
        data: { id: id },
        success: function () {
            GetAllNotes();
        },
        error: function (error) {
            console.log(error);
            swal("Erro ao remover lembrete!", { icon: "error" })
        }
    });
}

function ShowNotes(notes) {
    $("#note-list").empty();

    if (notes.length === 0) {
        let alertEmptyList = $("<p>").text("Não foram encontrados lembretes!");
        $("#note-list").append(alertEmptyList);
        return;
    }

    let noteGroup = {};

    for (let i = 0; i < notes.length; i++) {
        let note = notes[i];
        let data = new Date(note.date).toLocaleDateString('en-GB');

        if (!noteGroup[data]) {
            noteGroup[data] = [];
        }

        noteGroup[data].push(note);
    }

    for (let data in noteGroup) {
        let dayNotes = noteGroup[data];

        let ul = $("<ul>").text(data);
        ul.addClass("date-design")

        for (let j = 0; j < dayNotes.length; j++) {
            let dayNote = dayNotes[j];

            let li = $("<li>").text(dayNote.name);
            $("#note-list").append(ul);
            ul.append(li)

            let bttnRemove = $("<button>").text("X");
            bttnRemove.addClass("btn-remove")
            bttnRemove.data("id", dayNote.id);
            bttnRemove.click(function () {
                let id = $(this).data("id");
                RemoveNotes(id);
            });
            li.append(bttnRemove)
        }
    }
}

function AddNoteValidations(name, date) {

    if (date == null || date == "") {
        return "O campo data é obrigatório";
    }

    if (name == null || name == "") {
        return "O campo nome é obrigatório";
    }

    let dateAsDateTime = new Date(date);

    if (dateAsDateTime < Date.now()) {
        return "A data informada deve ser posterior a data de hoje"
    }

    return null;

}
