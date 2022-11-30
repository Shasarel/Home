import { HomeDto } from '../../dtos/HomeDto';
import { LoadComponendWithData } from '../../core/LoadComponentWithData';
import { Fieldset } from '../shared/Fieldset/Fieldset';
import { Card } from '../shared/Card/Card';


export function Home() {
    return LoadComponendWithData("api/home", ((data: HomeDto) =>
    (
        <Fieldset title="Energia">
            <Card title="Dzienna produkcja" value={data.energyToday.production} unit="kWh" maxValue={data.energyYesterday.production} percentageColor="green"></Card>
            <Card title="Dzienne zużycie" value={data.energyToday.consumption} unit="kWh" maxValue={data.energyYesterday.consumption} percentageColor="red"></Card>
            <Card title="Dzienny bilans" value={data.energyToday.store} unit="kWh" maxValue={data.energyYesterday.store } percentageColor="yellow"></Card>
            <Card title="Roczna produkcja" value={data.energyThisYear.production} unit="kWh" maxValue={data.energyLastYear.production} percentageColor="green"></Card>
            <Card title="Roczne zużycie" value={data.energyThisYear.consumption} unit="kWh" maxValue={data.energyLastYear.consumption} percentageColor="red"></Card>
            <Card title="Całkowity blians" value={data.energyAll.store} unit="kWh" maxValue={data.maxEnergyStore} percentageColor="yellow"></Card>
        </Fieldset>
        )))
}
