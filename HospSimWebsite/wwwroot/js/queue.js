
async function startQueue(){
    var patients;
    await $.ajax({
        url: "Queue/GetPatients",
        success: function(result){
            patients = result;
        }
    });
    
    if(patients.length === 0){
        swal({
            title: "No work for you.",
            text: "The queue is empty.",
            button: "Go back to drinking coffee."
        })
    }
    else{
        swal({
            title: `There are ${patients.length} patients waiting for you`,
            text: "Welcome to the queue, press Start",
            button: "Start"
        }).then(async value => {
            await showPatients(patients).then(function(){
                console.log("die");
            });
        })
    }
}

function endQueue(){
    console.log("Its over");
}

async function showPatients(patients){
    var firstKey = Object.keys(patients)[0];
    swal({
        title: `${Object.keys(patients).length} patients remaining.`,
        text: `${patients[firstKey].name}, ${patients[firstKey].age}. `,
        icon: "info",
        buttons: ["Approve", "Deny"],
        dangerMode: true
    }).then(async willDelete => {
        if (willDelete) {
            await $.ajax({
                type: "POST",
                url: "Queue/DenyPatient",
                data: patients[firstKey],
            });
        } else {
            await $.ajax({
                type: "POST",
                url: "Queue/ApprovePatient",
                data: patients[firstKey],
            });
        }

        delete patients[firstKey];
        if (patients.length !== 0) {
            console.log("Next Patient")
            showPatients(patients)
        } else {
            console.log("CLosing..")
            endQueue();
        }
    })
}


