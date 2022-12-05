import { ElectricityChartDataDto } from "./ElectricityChartDataDto";
import { EnergyDto } from "./EnergyDto";

export interface EnergyHistoryDto {
    energy: EnergyDto;
    energyPrevious: EnergyDto;
    chartData: ElectricityChartDataDto
}