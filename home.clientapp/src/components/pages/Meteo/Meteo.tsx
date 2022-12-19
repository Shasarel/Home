import { LoadComponendWithData } from '../../../core/LoadComponentWithData';
import { Fieldset } from '../../shared/Fieldset/Fieldset';
import { MeteoDto } from '../../../dtos/Meteo/MeteoDto';
import { NavigateToHistory } from '../../shared/NavigateToHistory/NavigateToHistory';
import AppRoutes from '../../../AppRoutes';
import { CardArrow } from '../../shared/Card/CardArrow';
import { CardDust } from '../../shared/Card/CardDust';

export function Meteo() {
    return <LoadComponendWithData url="api/meteo/now" componentCallback={((data: MeteoDto) =>
    (
        <div className="flex-column-center">
            <Fieldset title="Aktualne wartości">
                <CardArrow title="Temperatura" value={data.temperature} unit="°C" change={data.temperatureChange} />
                <CardArrow title="Ciśnienie" value={data.pressure} unit="hPa" change={data.pressureChange} />
                <CardDust title="Pył PM2.5" value={data.dust} unit="µg/m³" />
            </Fieldset>
            <NavigateToHistory path={AppRoutes.MeteoHistory.path} />
        </div>
    ))} interval={5000}/>;
}