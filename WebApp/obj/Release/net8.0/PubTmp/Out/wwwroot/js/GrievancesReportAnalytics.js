let chartInstance;
let data = [];

let districtData = [];
let grievanceData = [];

function showLoader() {
    document.getElementById('universalLoader').style.display = 'flex';
}
function hideLoader() {
    document.getElementById('universalLoader').style.display = 'none';
}

function getRandomColor() {
    const r = Math.floor(Math.random() * 256);
    const g = Math.floor(Math.random() * 256);
    const b = Math.floor(Math.random() * 256);
    return `rgba(${r}, ${g}, ${b}, 0.8)`; // Random color with 0.8 transparency
}

function generateRandomColors(count) {
    const colors = [];
    for (let i = 0; i < count; i++) {
        colors.push(getRandomColor());
    }
    return colors;
}

const chartData = {
    labels: [],
    datasets: [{
        label: 'Total Cases',
        data: [],
        backgroundColor: [],
        borderColor: [],
        borderWidth: 1
    }]
};

const chartConfig = {
    type: 'bar',
    data: chartData,
    options: {
        plugins: {
            legend: {
                display: false
            },
            tooltip: {
                callbacks: {
                    label: function (context) {
                        const index = context.dataIndex;
                        const total = grievanceData[index]?.total || 0;
                        const pending = grievanceData[index]?.pending || 0;
                        const resolved = grievanceData[index]?.resolved || 0;
                        return [
                            `Total: ${total}`,
                            `Pending: ${pending}`,
                            `Resolved: ${resolved}`
                        ];
                    }
                }
            }
        },
        scales: {
            x: {
                grid: {
                    display: false
                }
            },
            y: {
                beginAtZero: true,
                grid: {
                    display: true // Show horizontal gridlines
                }
            }
        }
    }
};

function fetchGrivancesCountData() {
    return $.ajax({
        url: '/Reports/GetGrievanceAnalyticsCountData',
        type: 'GET',
        success: function (response) {
            if (response && Array.isArray(response)) {
                grievanceData = response.map(item => ({
                    DistrictName: item.districtName,
                    total: item.totalGrievances,
                    pending: item.pending,
                    resolved: item.resolved
                }));

                // Update the chart with fetched data
                displayGrievanceDataInChart();
            } else {
                console.warn("No data received or response is not an array.");
            }
        },
        error: function () {
            console.error("Error fetching grievance data.");
        }
    });
}


function displayGrievanceDataInChart() {
    // Extract labels and totals from the grievance data
    const labels = grievanceData.map(item => item.DistrictName);
    const totals = grievanceData.map(item => item.total);

    // Generate random colors for the chart
    const barColors = generateRandomColors(labels.length);

    // Update chart data
    chartData.labels = labels;
    chartData.datasets[0].data = totals;
    chartData.datasets[0].backgroundColor = barColors;
    chartData.datasets[0].borderColor = barColors.map(color => color.replace(/0\.8\)$/, '1)'));

    // Refresh the chart
    chartInstance.update();
    hideLoader();
}

$(document).ready(function () {
    showLoader();
    // Initialize the chart
    const ctx = document.getElementById('myChart').getContext('2d');
    chartInstance = new Chart(ctx, chartConfig);

    // Fetch data and display it in the chart
    fetchGrivancesCountData();

    // Load the partial view
    $.ajax({
        url: '/Reports/_GrievancesAnalyticsList',
        dataType: 'html',
        success: function (response) {
            $('#GrievanceReportPartialView').html('');

        }
    });
});