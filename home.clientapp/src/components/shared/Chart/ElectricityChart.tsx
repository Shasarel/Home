import { ElectricityChartDataDto } from "../../../dtos/Energy/ElectricityChartDataDto";
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
    Filler,
    BarElement,
} from 'chart.js';
import { Bar, Line } from 'react-chartjs-2';
import './Chart.css'

ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
    Filler,
    BarElement,
);


const options = {
    responsive: true,
    maintainAspectRatio: false,
    pointRadius: 0,
    borderWidth: 1,
    plugins: {
        legend: {
            position: 'top' as const,
        },
        title: {
            display: true,
            text: 'Wykres mocy (W)',
            color: "#3E5569",
            font: {
                size: 20
            }
        },
        tooltip: {
            mode: 'index' as const,
            position: 'nearest' as const,
            intersect: false
        }
    },
};


type ElectricityChartProps = {
    chartData: ElectricityChartDataDto
}

export function ElectricityChart({ chartData }: ElectricityChartProps) {
    const data = {
        labels: chartData.labels,
        datasets: [
            {
                fill: true,
                label: 'Produkcja',
                data: chartData.production,
                borderColor: 'rgba(25, 180, 25, 1)',
                backgroundColor: 'rgba(50, 200, 50, 0.2)',
                cubicInterpolationMode: 'monotone' as const,
            },
            {
                fill: true,
                label: 'Zużycie',
                data: chartData.consumption,
                borderColor: 'rgba(210, 15, 15, 1)',
                backgroundColor: 'rgba(230, 30, 30, 0.2)',
                cubicInterpolationMode: 'monotone' as const,
            },
            {
                fill: true,
                label: 'Wykorzystanie',
                data: chartData.use,
                borderColor: 'rgba(5, 5, 231, 1)',
                backgroundColor: 'rgba(25, 25, 250, 0.2)',
                cubicInterpolationMode: 'monotone' as const,
                hidden: true
            },
            {
                fill: true,
                label: 'Pobieranie',
                data: chartData.import,
                borderColor: 'rgba(100, 100, 5, 1)',
                backgroundColor: 'rgba(230, 230, 30, 0.2)',
                cubicInterpolationMode: 'monotone' as const,
                hidden: true
            },
            {
                fill: true,
                label: 'Oddawanie',
                data: chartData.export,
                borderColor: 'rgba(30, 190, 190, 1)',
                backgroundColor: 'rgba(50, 210, 210, 0.2)',
                cubicInterpolationMode: 'monotone' as const,
                hidden: true
            },
            {
                fill: true,
                label: 'Magazynowanie',
                data: chartData.store,
                borderColor: 'rgba(140, 30, 100, 1)',
                backgroundColor: 'rgba(180, 60, 130, 0.2)',
                cubicInterpolationMode: 'monotone' as const,
                hidden: true
            },
        ],
    };

    if (chartData.chartType === "bar")
        options.plugins.title.text = "Wykres energii (kWh)";

    return (
        <div className="chart-container">
            {chartData.chartType === 'line' ?
                <Line data={data} options={options}></Line> :
                <Bar data={data} options={options}></Bar>}
        </div>
    );
}