// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function fromTable() {
    let form = document.getElementById('frm');
    let table = document.getElementById('filter-table');

    form.addEventListener('keyup', function (ev) {

        let
            name = form.elements[0].value,
            age = form.elements[1].value,
            marrige = form.elements[2].value,
            phone = form.elements[3].value,
            salary = form.elements[4].value;

        for (var i = 1; i < table.rows.length; i++) {
            table.rows[i].style.display = "";

            if (
                table.rows[i].cells[0].innerHTML.indexOf(name) == -1 ||
                table.rows[i].cells[1].innerHTML.indexOf(age) == -1 ||
                table.rows[i].cells[2].innerHTML.indexOf(marrige) == -1 ||
                table.rows[i].cells[3].innerHTML.indexOf(phone) == -1 ||
                table.rows[i].cells[4].innerHTML.indexOf(salary) == -1
            ) {
                table.rows[i].style.display = "none";
            }
        }
    })
}
fromTable();
