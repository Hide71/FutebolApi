const listaTimes = document.getElementById('lista-times')
const urlApi = "http://localhost:5242/times";

const getAllTimes = async () => {
    try {
        const response = await fetch(urlApi);
            if (!response.ok){
                throw new Error("erro ao buscar os times!");
                
            }
            const times = await response.json();
            times.forEach((time) => {
                const newli = document.createElement('li');
                newli.innerText = `Nome: ${time.nome}`;
                listaTimes.appendChild(newli);
                
            });
            
        } catch (error) {
            listaTimes.innerText = error.message
            
        }
    };
    getAllTimes();