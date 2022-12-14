import { EnergyDto } from "./Energy/EnergyDto";

export interface HomeDto {
    energyToday: EnergyDto;
    energyYesterday: EnergyDto;
    energyThisYear: EnergyDto;
    energyLastYear: EnergyDto;
    energyAll: EnergyDto;
    maxEnergyStore: number;
}