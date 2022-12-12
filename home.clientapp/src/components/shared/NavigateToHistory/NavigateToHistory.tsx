import moment from "moment";
import { Moment } from "moment";
import { useState } from "react";
import { Button } from "../Button/Button";
import { DataPicker } from "../DataPicker/DataPicker";
import { Fieldset } from "../Fieldset/Fieldset";
import "./NavigateToHistory.css"

const dateFromat = "YYYY-MM-DD"
const minDate = moment("2018-06-21", dateFromat);
const today = moment();
const firstDayOfMonth = moment(today.format("YYYY-MM-01"), dateFromat);
const firstDayOfYear = moment(today.format("YYYY-01-01"), dateFromat);

interface NavigateToHistoryProps {
    path: string,
}

export function NavigateToHistory({ path }: NavigateToHistoryProps) {
    const [dateFrom, setDateFrom] = useState<moment.Moment | null>(null);
    const [dateTo, setDateTo] = useState<moment.Moment | null>(null);

    return (
        <Fieldset title="Historia">
            <Button route={GetPathToHistory(today, today, path)} title="Obecny dzień"></Button>
            <Button route={GetPathToHistory(firstDayOfMonth, today, path)} title="Obecny miesiąc"></Button>
            <Button route={GetPathToHistory(firstDayOfYear, today, path)} title="Obecny rok"></Button>
            <Button route={GetPathToHistory(minDate, today, path)} title="Od początku"></Button>
            <div className="from-to-date-picker">
                <DataPicker title="Od" date={dateFrom} setDate={setDateFrom}></DataPicker>
                <DataPicker title="Do" date={dateTo} setDate={setDateTo}></DataPicker>
                <Button route={GetPathToHistory(dateFrom, dateTo, path)} title="Według dat"></Button>
            </div>
        </Fieldset>
    );
}

function GetPathToHistory(dateFrom: Moment | null, dateTo: Moment | null, path: string) {
    if (dateFrom === null || dateTo === null || dateFrom.date > dateTo.date)
        return "";

    return path
        .replace(":from", dateFrom.format(dateFromat))
        .replace(":to", dateTo.format(dateFromat));
}