import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/layout/Layout/Layout';
import './App.css';

function App() {
  return (
      <Layout>
          <Routes>
              {Object.values(AppRoutes).map((route, index) => {
                  const { element, ...rest } = route;
                  return <Route key={index} {...rest} element={element} />;
              })}
          </Routes>
      </Layout>
  );
}

export default App;
