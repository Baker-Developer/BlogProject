let index = 0;

function AddTag() {
    // Get A Reference To The TagEntry Input Element
    let tagEntry = document.getElementById("TagEntry")

    // Use The New Search Function To Dectect An Error State
    let searchResult = search(tagEntry.value);

    if (searchResult != null) {
        //Trigger My Sweet Alert For Whatever Condintion Is Contained In The searchResults var
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 7000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
        })

        Toast.fire({
            icon: 'error',
            title: 'Duplicate Tags Inputted',
            text:  searchResult,

        })


    } else {
        //Create A Select Option
        let newOption = new Option(tagEntry.value, tagEntry.value)
        document.getElementById("TagList").options[index++] = newOption;
    }


    //Clear Out The Tag Entry Control
    tagEntry.value = "";

    return true;

}

// The Seach Function Will Detect A Either An Empty Or Duplicate Tag
// The Search Will Also Return A Error If An Error Is Dectected
function search(str) {
    if (str == "") {
        return "Empty Tags Are Not Allowed";
    }

    let tagsElement = document.getElementById("TagList");
    if (tagsElement) {
        let options = tagsElement.options;
        for (let index = 0; index < options.length; index++) {
            if (options[index].value == str) {
                return `The Tag #${str} Tag Is Not Allowed (Duplicate Tag)`
            }
        }
    }

}


function DeleteTag() {

    let tagCount = 1;
    let tagList = document.getElementById("TagList");
    if (!tagList) {
        return false;
    } 

    if (tagList.selectedIndex == -1) {
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
        })

        Toast.fire({
            icon: 'error',
            title: 'Duplicate Tags Inputted',
            html: "<span>Choose A Tag Before Deleting</span>",
        })
        return true;
    }


    while (tagCount > 0) {

        if (tagList.selectedIndex >= 0) {
            tagList.options[tagList.selectedIndex] = null;
            --tagCount;
        } else {
            tagCount = 0;
            index--;
        }
    }

}


$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
})

//Look for the tagValues variable to see if it has data
if (tagValues != '') {
    let tagArray = tagValues.split(",");
    for (let loop = 0; loop < tagArray.length; loop++) {
        //Load up or replace the options we have
        ReplaceTag(tagArray[loop], loop);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}

