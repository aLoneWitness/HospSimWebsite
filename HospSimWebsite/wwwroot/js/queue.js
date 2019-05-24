
function startQueue(patients){
    swal({
        title: `There are ${patients.length} patients waiting for you`,
        text: "Welcome to the queue, press Start"
    }).then(async value => {
        await showPatients(patients).then(function(){
            console.log("die");
        });
    })
}

function endQueue(){
    console.log("Its over");
}

async function showPatients(patients){
    swal({
        title: `${patients.length} patients remaining.`,
        text: `${patients[0].name}, ${patients[0].age}. `,
        icon: "info",
        buttons: ["Approve", "Deny"],
        dangerMode: true
    }).then(willDelete => {
        if(willDelete){
            $.post("Queue/DenyPatient", {
                id: patients[0]
            });
        }
        else {
            $.post("Queue/ApprovePatient", {
                id: patients[0]
            });
        }
        
        patients.shift();
        if(patients.length !== 0){
            showPatients(patients)
        }
        else{
            endQueue();
        }
    })
}


