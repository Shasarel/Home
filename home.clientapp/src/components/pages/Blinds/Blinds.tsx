import moment, { Moment } from "moment";
import { useEffect, useState } from "react";
import { LoadComponendWithData } from "../../../core/LoadComponentWithData";
import { BlindScheduleDto } from "../../../dtos/Blinds/BlindScheduleDto";
import { BlindsDto } from "../../../dtos/Blinds/BlindsDto";
import { BlindTaskDto } from "../../../dtos/Blinds/BlindTaskDto";
import { ComboBox } from "../../shared/ComboBox/ComboBox";
import { Table } from "../../shared/Table/Table";

const actions = ["Otwórz", "Zamknij", "Stop"];
const devices = ["Mały pokój", "Pokój Wojtek", "Pokój Jakub - duże", "Pokój Jakub - małe", "Sypialnia", "Balkon", "Salon", "Jadalnia", "Kuchnia"];
const timeOfDay = ["Świt", "Wschód", "Zenit", "Zachód", "Zmierzch", "Stała godzina"];

export function Blinds() {
    const [selected, setSelected] = useState<number>();
    const [now, setNow] = useState<Moment>(moment());

    function handleChange(e: React.ChangeEvent<HTMLSelectElement>) {
        setSelected(e.target.selectedIndex)
    }

    useEffect(() => {
        const inter = setInterval(() =>
            setNow(moment()), 1000);

        return () => {
            clearInterval(inter);
        };
    }, []);

    function RemainingTime(datetime: moment.Moment): string {
        var duration = moment.duration((datetime.diff(now)))

        return `${duration.hours() + (duration.days() * 24)}h ${duration.minutes()}m ${duration.seconds()}s`;
    }

    function MapBlindsTaskToRow(blindTasks: BlindTaskDto[]): string[][] {
        return blindTasks.map((blindTask) =>
            [actions[blindTask.action], moment(blindTask.datetime).format("yyyy-MM-DD HH:mm"), RemainingTime(moment(blindTask.datetime)), blindTask.plannedBy]);
    }

    function MapBlindsScheduleToRow(blindSchedules: BlindScheduleDto[]): string[][] {
        return blindSchedules.map((blindSchedule) =>
            [actions[blindSchedule.action], timeOfDay[blindSchedule.hourType], `${blindSchedule.timeOffset} m`, blindSchedule.plannedBy]);
    }

    return (
        <div className="flex-column-center">
            <ComboBox options={devices} onChange={handleChange}></ComboBox>
            {selected !== undefined ?
                <LoadComponendWithData url={`api/blinds/blindData?blindId=${selected}`} componentCallback={((data: BlindsDto) => (
                    <div className="flex-column-center">
                        <Table title={"Zaplanowane zadania"} headers={["Akcja", "Czas", "Pozostały czas", "Zaplanowane przez"]} rows={MapBlindsTaskToRow(data.blindTasks)} deleteUrls={data.blindTasks.map(x => `api/blinds/deleteBlindTask?id=${x.id}`)} />
                        <Table title={"Harmonogram"} headers={["Akcja", "Pora dnia", "Czas", "Zaplanowane przez"]} rows={MapBlindsScheduleToRow(data.blindSchedules)} deleteUrls={data.blindSchedules.map(x => `api/blinds/deleteBlindSchedule?id=${x.id}`)} />
                    </div>
                ))} />
                :
                ""}
        </div>
    );
}