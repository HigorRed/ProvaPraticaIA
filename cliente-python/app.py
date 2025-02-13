import requests


url = "http://localhost:5241/api/users"


response = requests.get(url)


if response.status_code == 200:
    data = response.json()
    
   
    for user in data:
      
        if user['idade'] < 30:
            categoria = "Jovem"
        elif 30 <= user['idade'] <= 40:
            categoria = "Adulto"
        else:
            categoria = "Sênior"
      
        print(f"Nome: {user['nome']}")
        print(f"Idade: {user['idade']}")
        print(f"Cidade: {user['cidade']}")
        print(f"Profissão: {user['profissao']}")
        print(f"Categoria: {categoria}")
        print("-" * 30) 
else:
    print("Erro ao obter os usuários.")
