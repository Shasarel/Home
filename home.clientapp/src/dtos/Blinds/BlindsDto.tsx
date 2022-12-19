import { BlindScheduleDto } from "./BlindScheduleDto";
import { BlindTaskDto } from "./BlindTaskDto";

export interface BlindsDto {
    blindTasks: BlindTaskDto[],
    blindSchedules: BlindScheduleDto[]
}