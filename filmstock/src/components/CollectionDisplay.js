import '../App.css';
import "@material-tailwind/react/tailwind.css";
import Layout from './layout/Layout';

const CollectionDisplay = (props) => {

  return (
    <div className="CollectionDisplay">
        <Layout>
            <div className="grid grid-cols-6 gap-4 md:container md:mx-auto mt-6">
                
            </div>
        </Layout>
    </div>
  );
}

export default CollectionDisplay;