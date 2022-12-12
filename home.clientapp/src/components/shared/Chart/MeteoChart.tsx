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
import { Line } from 'react-chartjs-2';
import { MinAvgMaxChartData } from '../../../dtos/MinAvgMaxChartDataDto';
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


type MeteoChartProps = {
    chartData: MinAvgMaxChartData,
    labels: string[],
    title: string
}

export function MeteoChart({ chartData, labels, title }: MeteoChartProps) {
  const options = {
        responsive: true,
        maintainAspectRatio: false,
        pointRadius: 0,
        borderWidth: 2,
        plugins: {
            legend: {
                position: 'top' as const,
            },
            title: {
                display: true,
                text: title,
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

    const data = {
        labels: labels,
        datasets: [
            {
                fill: false,
                label: 'Min',
                data: chartData.min,
                borderColor: 'rgba(25, 180, 25, 1)',
                backgroundColor: 'rgba(50, 200, 50, 0.2)',
                hidden: true,
                cubicInterpolationMode: 'monotone' as const,
            },
            {
                fill: false,
                label: 'Avg',
                data: chartData.avg,
                borderColor: 'rgba(210, 15, 15, 1)',
                backgroundColor: 'rgba(230, 30, 30, 0.2)',
                cubicInterpolationMode: 'monotone' as const,
            },
            {
                fill: false,
                label: 'Max',
                data: chartData.max,
                borderColor: 'rgba(5, 5, 231, 1)',
                backgroundColor: 'rgba(25, 25, 250, 0.2)',
                cubicInterpolationMode: 'monotone' as const,
                hidden: true
            },
        ],
    };

    return (
        <div className="chart-container">
            <Line data={data} options={options}></Line> :
        </div>
    );
}