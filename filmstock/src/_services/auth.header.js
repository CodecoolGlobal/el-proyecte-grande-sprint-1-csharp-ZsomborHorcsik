export default function authHeader() {
    const token = JSON.parse(localStorage.getItem("user"));
  
    if (token) {
      return { "x-auth-token": user.accessToken };
    } else {
      return {};
    }
  }