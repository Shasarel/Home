import { EnergyDto } from "./EnergyDto";

export interface EnergyHistoryDto {
    energy: EnergyDto;
    energyPrevious: EnergyDto;
}