import { MinAvgMaxChartData } from "./MinAvgMaxChartDataDto";

export interface MeteoChartData {
    temperature: MinAvgMaxChartData,
    pressure: MinAvgMaxChartData,
    dust: MinAvgMaxChartData,
    labels: string[]
}