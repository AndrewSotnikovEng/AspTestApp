var students = null;

$(function () {

    let url = 'https://localhost:44346/studentapi';

    fetch(url)
        .then(res => res.json())
        .then(data => students = data)
});


document.getElementById("StudentIdInput").addEventListener("keypress",
    function () {
        if (students == null) {
            console.log("Please check connection!")
            alert("Not able to access API")
        }
        console.log("Students", students)
        $("#StudentIdInput").autocomplete({
            source: students
        });
    }
)