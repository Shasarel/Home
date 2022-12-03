import { useState } from 'react';
import { LoadComponendWithData } from '../../../core/LoadComponentWithData';
import { EnergyDto } from '../../../dtos/EnergyDto';
import { Button } from '../../shared/Button/Button';
import { Card } from '../../shared/Card/Card';
import { Fieldset } from '../../shared/Fieldset/Fieldset';
import { DataPicker } from '../../shared/DataPicker/DataPicker';
import './Energy.css';
import moment, { Moment } from 'moment';
import AppRoutes from '../../../AppRoutes';

const maxPowerProduction = 8500;
const dateFromat = "YYYY-MM-DD"
const minDate = moment("2018-06-21", dateFromat);
const today = moment();
const firstDayOfMonth = moment(today.format("YYYY-MM-01"), dateFromat);
const firstDayOfYear = moment(today.format("YYYY-01-01"), dateFromat);

export function Energy() { 

    const [dateFrom, setDateFrom] = useState<moment.Moment |null>(null);
    const [dateTo, setDateTo] = useState<moment.Moment | null>(null);

    return LoadComponendWithData("api/energy/currentpower", ((data: EnergyDto) =>
    (
        <div className="flex-column-center">
            <Fieldset title="Moc chwilowa">
                <Card title="Produkowana" value={data.production} unit="W" maxValue={maxPowerProduction} percentageColor="green"></Card>
                <Card title="Pobierana" value={data.import} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></Card>
                <Card title="Oddawana" value={data.export} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></Card>
                <Card title="Zużywana" value={data.consumption} unit="W" maxValue={maxPowerProduction} percentageColor="red"></Card>
                <Card title="Wykorzystywana" value={data.use} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></Card>
                <Card title="Magazynowana" value={data.store} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></Card>
            </Fieldset>
            <Fieldset title="Historia">
                <Button route={GetPathToHistory(today, today)} title="Obecny dzień"></Button>
                <Button route={GetPathToHistory(firstDayOfMonth, today)} title="Obecny miesiąc"></Button>
                <Button route={GetPathToHistory(firstDayOfYear, today)} title="Obecny rok"></Button>
                <Button route={GetPathToHistory(minDate, today)} title="Od początku"></Button>
                <div className="energy-date-picker">
                    <DataPicker title="Od" date={dateFrom} minDate={minDate} maxDate={today} setDate={setDateFrom}></DataPicker>
                    <DataPicker title="Do" date={dateTo} minDate={minDate} maxDate={today} setDate={setDateTo}></DataPicker>
                    <Button route={GetPathToHistory(dateFrom, dateTo)} title="Według dat"></Button>
                </div>
            </Fieldset>
        </div>
    )), 5000);
}

function GetPathToHistory(dateFrom: Moment | null, dateTo: Moment | null) {
    if (dateFrom === null || dateTo === null || dateFrom > dateTo)
        return "";

    return AppRoutes
        .EnergyHistory
        .path
        .replace(":from", dateFrom.format(dateFromat))
        .replace(":to", dateTo.format(dateFromat));
}