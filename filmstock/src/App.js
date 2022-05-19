import './App.css';
import "@material-tailwind/react/tailwind.css";
import Layout from './components/Layout';

function App() {
  return (
    <div className="App">
      <Layout>
        <div className='landing-hero'>
          <h1>Welcome to FilmStock!</h1>
        </div>
      </Layout>
    </div>
  );
}

export default App;
