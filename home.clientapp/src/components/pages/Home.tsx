import { HomeDto } from '../../dtos/HomeDto';
import { LoadComponendWithData } from '../../core/LoadComponentWithData';
import { Fieldset } from '../shared/Fieldset/Fieldset';
import { CardBar } from '../shared/Card/CardBar';


export function Home() {
    return <LoadComponendWithData url="api/home" componentCallback={((data: HomeDto) =>
    (
        <Fieldset title="Energia">
            <CardBar title="Dzienna produkcja" value={data.energyToday.production} unit="kWh" maxValue={data.energyYesterday.production} percentageColor="green"></CardBar>
            <CardBar title="Dzienne zużycie" value={data.energyToday.consumption} unit="kWh" maxValue={data.energyYesterday.consumption} percentageColor="red"></CardBar>
            <CardBar title="Dzienny bilans" value={data.energyToday.store} unit="kWh" maxValue={data.energyYesterday.store} percentageColor="yellow"></CardBar>
            <CardBar title="Roczna produkcja" value={data.energyThisYear.production} unit="kWh" maxValue={data.energyLastYear.production} percentageColor="green"></CardBar>
            <CardBar title="Roczne zużycie" value={data.energyThisYear.consumption} unit="kWh" maxValue={data.energyLastYear.consumption} percentageColor="red"></CardBar>
            <CardBar title="Całkowity blians" value={data.energyAll.store} unit="kWh" maxValue={data.maxEnergyStore} percentageColor="yellow"></CardBar>
        </Fieldset>
    ))}/>
}
