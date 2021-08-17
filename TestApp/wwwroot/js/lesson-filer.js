function getElementsById(elementID) {
    var elementCollection = new Array();
    var allElements = document.getElementsByTagName("*");
    for (i = 0; i < allElements.length; i++) {
        if (allElements[i].id == elementID)
            elementCollection.push(allElements[i]);

    }
    return elementCollection;
}


document.getElementById("filterInput").addEventListener("keyup",
    function () {
        let serachTerm = document.getElementById("filterInput").value.toLowerCase();
        //console.log("Serach term", serachTerm);
        //console.log(getElementsById("lesson-item"));
        elements = getElementsById("lesson-item");
        for (element of elements) {
            let content = String(element.innerHTML).toLowerCase();
            if (content.includes(serachTerm)) {
                element.parentElement.hidden = false;
            } else {
                element.parentElement.hidden = true;
            }
        }
        getElementsById("lesson-item")
    }
)