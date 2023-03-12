# TicTacToe
 
# HomeController
[Route("/")]

[HttpPost("login")]
public async Task<IActionResult> LogIn([FromQuery] string name, [FromQuery] string redirectUrl)
----------------------------
Регистрирует пользователя.

return: Перенаправляет на указанную страницу, при условии что пользователь уже авторизирован.
return: Перенаправляет на указанную страницу, при успешной регистрации.

# TicTacToeController
[Route("[controller]")]

[HttpPost("ready")]
public async Task<IActionResult> SetReady()
----------------------------
Добавляет пользователя в лист ожидающих игры.

return: Status401Unauthorized, при условии что пользователь не авторизован или не имеет роли "Player".

return: Status200OK.


[HttpGet("checksession")]
public async Task<IActionResult> CheckSession()
----------------------------
Определяет нашлась ли сессия.

return: Status200OK. - Количество сессий, при условии, что есть хоть одна сессия.
return: Status403Forbidden.
return: Status200OK. - Ожидаю соперника.


[HttpPut("setmove")]
public async Task<IActionResult> SetMove([FromQuery] int x, [FromQuery] int y)
----------------------------
Фиксирует ход.

return: Status401Unauthorized, при условии что пользователь не авторизован или не имеет роли "Player".
return: Status200OK, при условии если победитель определен.
return: Status200OK, при условии если успешно сделан ход.
return: Status200OK - Что-то не так, ход противника или клетка занята. При условии если клетка занята или ход опонента.
return: Status200OK - Вы не нашли игру! При условии, если сессия не найдена.


[HttpGet("drawmap")]
public async Task<IActionResult> DrawMap()
----------------------------
Отрисовывает карту.

return: Status401Unauthorized, при условии что пользователь не авторизован или не имеет роли "Player".
return: Status200OK - отрисовывает текущее состояние карты.
return: Status200OK - Вы не нашли игру! При условии, если сессия не найдена.
