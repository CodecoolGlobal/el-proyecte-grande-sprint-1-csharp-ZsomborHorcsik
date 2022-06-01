import Layout from './Layout';
import '../App.css';
import { useParams } from 'react-router-dom';

const UserDisplay = (props) => {
    const userName = useParams();
    const {data, error} = useFetch(`api/User/${userName}`);
  
    if(error) console.log(error);
  
    return (
          <Layout>
            <div class="center">
                <div class="container">
                <div class="left">  
                    <div class="title__contain">
                    <div class="username">{data?.userName}</div>
                    <div class="title">Proffessional Critic</div>
                    </div>
                </div>
                <div class="right">
                    <div class="rightbox">
                    <span class="large">{data?.Collection.length}</span>
                    <span class="small">Posts</span>
                    </div>
                    <div class="rightbox">
                    <span class="small">Email:</span>
                    <span class="small">{data?.email}</span>
                    </div>
                </div>
                </div>
            </div>
          </Layout>
    );
  }
  
  export default UserDisplay;