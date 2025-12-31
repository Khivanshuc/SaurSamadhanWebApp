document.addEventListener('DOMContentLoaded', function () {
    const resetPasswordBtn = document.getElementById('resetPasswordBtn');
    const resetPasswordPopup = document.getElementById('resetPasswordPopup');
    const closePopup = document.getElementById('closePopup');
    const updatePasswordBtn = document.getElementById('updatePasswordBtn');

    // Show popup when reset password button is clicked
    resetPasswordBtn.addEventListener('click', function () {
        resetPasswordPopup.style.display = 'flex';
    });

    // Close popup when the close button is clicked
    closePopup.addEventListener('click', function () {
        resetPasswordPopup.style.display = 'none';
    });

    // Close popup when clicking outside the popup content
    window.addEventListener('click', function (event) {
        if (event.target === resetPasswordPopup) {
            resetPasswordPopup.style.display = 'none';
        }
    });

    // Update password button click
    updatePasswordBtn.addEventListener('click', function () {
        const oldPassword = document.getElementById('oldPassword').value;
        const newPassword = document.getElementById('newPassword').value;
        const confirmPassword = document.getElementById('confirmPassword').value;

        if (newPassword !== confirmPassword) {
            alert('New Password and Confirm Password do not match.');
            return;
        }

        // Here you can add the code to update the password in your backend
        alert('Password updated successfully!');

        // Close the popup
        resetPasswordPopup.style.display = 'none';
    });
});
getUserDetail();
function getUserDetail() {
    $.ajax({
        url: '/Admin/UserProfileDetail', 
        dataType: 'json', 
        success: function (response) {
            console.log(response);
            if (response.success) {
                fillUserProfileDetail(response);
            } else {
                alert(response.message || "No Data Found");
            }

        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
            alert("An error occurred while fetching the data.");
        }
    });
}

function fillUserProfileDetail(response) {
    // If the response is successful and data is present, bind the data to the form fields
    $('#username').val(response.data.userName);
    $('#name').val(response.data.userName); // Assuming name is the same as username for now
    $('#password').val(response.data.password); // Handle password securely
    $('#district').val(response.data.district);
    $('#officeLevel').val(response.data.officeLevel);
    $('#modal_username').val(response.data.userName);
}

function passwordUpdateBtnClicked() {
    var oldPassword = $('#oldPassword').val();
    var newPassword = $('#newPassword').val();
    var confirmPassword = $('#confirmPassword').val();

    if (newPassword !== confirmPassword) {
        alert("New Password and Confirm Password do not match. Please try again.");
        return; // Exit the function if passwords do not match
    }

    updatePassword(oldPassword, newPassword);
}

function updatePassword(oldPassword, newPassword) {
    $.ajax({
        url: '/Admin/UpdatePassword',
        data: { OldPassword: oldPassword, NewPassword: newPassword},
        dataType: 'json',
        success: function (response) {
            console.log(response);
            if (response.success) {
                fillUserProfileDetail(response);
            } else {
                alert(response.message || "No Data Found");
            }

        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
            alert("An error occurred while fetching the data.");
        }
    });
}